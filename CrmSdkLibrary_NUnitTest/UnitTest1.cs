using CrmSdkLibrary;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static CrmSdkLibrary.Definition.Email;

namespace CrmSdkLibrary_NUnitTest
{
	public class Tests
	{
		public class AppSettings
		{
			public CrmConfig CrmConfig { get; set; }
		}

		private AppSettings Config { get; set; }

		[SetUp]
		public void Setup()
		{
			using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/secrets.json"))
			{
				Config = JsonConvert.DeserializeObject<AppSettings>(reader.ReadToEnd());
			}
		}

		[Test]
		public void Test1()
		{
			var item = Connection.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
				Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

			// Query Expression Example

			// Where
			using (var context = new OrganizationServiceContext(Connection.Service))
			{
				var q = from e in context.CreateQuery("contact")
						where e.GetAttributeValue<string>("mobilephone") == "01012345678"
						where e.GetAttributeValue<int>("statecode") == 0
						orderby e.GetAttributeValue<DateTime>("createdon") descending
						select new
						{
							id = e.Id,
							code = e.GetAttributeValue<string>("fullname"),
						};
				var data = q.ToList();
			}

			// Left Join
			using (var context = new OrganizationServiceContext(Connection.Service))
			{
				var q = from a in context.CreateQuery("account")
						join c in context.CreateQuery("contact") on a.GetAttributeValue<Guid>("accountid") equals c.GetAttributeValue<Guid>("parentcustomerid") into _cg
						from c in _cg.DefaultIfEmpty() //left outer join
						where c.GetAttributeValue<int>("statecode") == 0
						where a.GetAttributeValue<int>("statecode") == 0
						where a.GetAttributeValue<string>("name") == "A" || a.GetAttributeValue<string>("name") == "B"
						select new
						{
							AccountId = a.Id,
							AccountName = a.GetAttributeValue<string>("name"),
							ContactsName = c.GetAttributeValue<string>("fullname"),
						};
				var data = q.ToList();
			}

			// Left Join Sub Query (SUM)
			//using (var context = new OrganizationServiceContext(CrmSdkLibrary.Connection.Service))
			//{
			//    var q = from a in context.CreateQuery("account")
			//            join c in (
			//                from _c in context.CreateQuery("opportunity")
			//                where _c.GetAttributeValue<Guid?>("parentaccountid") != null
			//                group _c by _c.GetAttributeValue<Guid>("parentaccountid") into _co
			//                select new
			//                {
			//                    ParentAccountId = _co.Key,
			//                    EstimatedValue = _co.Sum(x => x.GetAttributeValue<decimal>("estimatedvalue")),
			//                }
			//            ) on a.GetAttributeValue<Guid>("accountid") equals c.ParentAccountId into _cg
			//            from c in _cg.DefaultIfEmpty() //left outer join (subquery?)
			//            where c.EstimatedValue > 0
			//            select new
			//            {
			//                AccountId = a.Id,
			//                c.EstimatedValue,
			//            };
			//    var data = q.ToList();
			//}

			// Left Join Grouping
			using (var context = new OrganizationServiceContext(Connection.Service))
			{
				var query = from ac in context.CreateQuery("account")
							join co in context.CreateQuery("contact") on ac["accountid"] equals co["parentcustomerid"] into coGroup
							from co in coGroup.DefaultIfEmpty()
							where (int)ac["statecode"] == 0 //&& (Guid)ac["accountid"] == recordId
							select new { Account = ac, Contact = co };

				var data = query.ToList().GroupBy(x => x.Account.Id).Select(aItem => new
				{
					Id = aItem.First().Account.Id,
					Name = aItem.First().Account.GetAttributeValue<string>("name"),
					CustomerSizeCode = aItem.First().Account.GetAttributeValue<OptionSetValue>("customersizecode")?.Value,
					TransactionCurrencyId = aItem.First().Account.GetAttributeValue<EntityReference>("transactioncurrencyid")?.Id,
					TransactionCurrencyIdName = aItem.First().Account.Contains("transactioncurrencyid") ? aItem.First().Account.FormattedValues["transactioncurrencyid"] : null,
					Contacts = aItem.Where(x => x.Contact != null && x.Contact.Contains("contactid") && (Guid)x.Contact["contactid"] != Guid.Empty).Select(cItem => new
					{
						Id = (Guid)cItem.Contact["contactid"], //Join Entity Has not Id Value.
						ParentCustomerId = cItem.Contact.Contains("parentcustomerid") ? cItem.Contact.GetAttributeValue<EntityReference>("parentcustomerid").Id : (Guid?)null,
						ParentCustomerIdName = cItem.Contact.Contains("parentcustomerid") ? cItem.Contact.GetAttributeValue<EntityReference>("parentcustomerid").Name : null, // Join Entity Has not FormattedValue
					}).ToList()
				}).ToList();
			}

			// Left Join Grouping - Other Way
			{
				var ec = Connection.Service.RetrieveMultiple(new QueryExpression("account")
				{
					ColumnSet = new ColumnSet(true),
					Criteria = new FilterExpression()
					{
						Conditions =
						{
							new ConditionExpression("statecode", ConditionOperator.Equal, 0),

							//new ConditionExpression("new_l_opportunity", ConditionOperator.Equal, recordId)
						}
					},
					LinkEntities =
					{
						new LinkEntity( "account", "contact","accountid","parentcustomerid", JoinOperator.LeftOuter)
						{
							EntityAlias = "co",
							Columns = new ColumnSet(true),
							LinkCriteria = new FilterExpression() {
							Conditions=
								{
									new ConditionExpression("statecode", ConditionOperator.Equal, 0),
								}
							}
						}
					}
				});
				var data = ec.Entities.GroupBy(x => x.Id).Select(item => new
				{
					Id = item.First().Id,
					Name = item.First().GetAttributeValue<string>("name"),
					CustomerSizeCode = item.First().GetAttributeValue<OptionSetValue>("customersizecode")?.Value,
					TransactionCurrencyId = item.First().GetAttributeValue<EntityReference>("transactioncurrencyid")?.Id,
					TransactionCurrencyIdName = item.First().Contains("transactioncurrencyid") ? item.First().FormattedValues["transactioncurrencyid"] : null,
					Revenue = item.First().GetAttributeValue<Money>("revenue")?.Value,
					CreditLimit = item.First().GetAttributeValue<Money>("creditlimit")?.Value,
					OpenRevenue = item.First().GetAttributeValue<Money>("openrevenue")?.Value,
					DoNotFax = item.First().GetAttributeValue<bool?>("donotfax") ?? false,
					ExchangeRate = item.First().GetAttributeValue<decimal?>("exchangerate"),
					NumberOfEmployees = item.First().GetAttributeValue<int?>("numberofemployees"),
					Contacts = item.Where(x => x.Contains("co.parentcustomerid"))?.Select(co => new
					{
						Id = co.GetAliasedValue<Guid>("co.contactid"),
						ParentCustomerId = co.Contains("parentcustomerid") ? co.GetAliasedValue<EntityReference>("parentcustomerid").Id : (Guid?)null,
						ParentCustomerIdName = co.Contains("parentcustomerid") ? co.FormattedValues["co.new_l_account"] : null,
					}).ToList()
				}).ToList();
			}

			// Inner Join

			Assert.Pass();
		}

		[Test]
		public async Task Api_ADALAsync()
		{
			WebApi_ADAL.Api.SetClientId(Config.CrmConfig.ClientId);
			var httpClient = await WebApi_ADAL.Api.GetWebApiHttpClient(Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.EnvironmentUrl);

			var user = await WebApi_ADAL.Api.User(httpClient);

			var objectTypeCode = await WebApi_ADAL.Api.GetObjectTypeCode(httpClient, "account");
			var calcRF = await WebApi_ADAL.Api.CalculateRollupField(httpClient, "account", "d11452ee-b338-ed11-9db1-000d3aa3b95d", "new_i_opportunity");
			var RD = await WebApi_ADAL.Api.RetrieveDuplicates(httpClient, "account", "046a76d8-0075-ec11-8943-0022485a0300");

			var logs = await WebApi_ADAL.Api.GetPluginTraceLogs(httpClient);
			Assert.Pass();
		}

		[Test]
		public void Api_MSAL()
		{
		}

		[Test]
		public async Task ExportAsync()
		{
			try
			{
				var service = Connection.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
					Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

				var currentOrg = service.Execute(new RetrieveCurrentOrganizationRequest()) as RetrieveCurrentOrganizationResponse;
				var url = currentOrg.Detail.Endpoints
					.Where(e => e.Key == Microsoft.Xrm.Sdk.Organization.EndpointType.WebApplication)
					.FirstOrDefault()
					.Value;
				var qe2 = new QueryExpression("account")
				{
					ColumnSet = new ColumnSet(true)
				};
				var abc = await service.RetrieveMultipleAsync(qe2);
				var qe = new QueryExpression("savedquery")
				{
					ColumnSet = new ColumnSet(true),
					Criteria = new FilterExpression()
					{
						Conditions =
					{
                        //new ConditionExpression("solutionid", ConditionOperator.Equal, new Guid()),
                        new ConditionExpression("returnedtypecode", ConditionOperator.Equal, "new_incident"),
						new ConditionExpression("isdefault", ConditionOperator.Equal, true),

                        //new ConditionExpression("savedqueryid", ConditionOperator.Equal, new Guid()),
                    }
					}
				};

				var defaultView = await service.RetrieveMultipleAsync(qe);

				var view = defaultView.Entities.First().ToEntityReference();
				string fetchXml = defaultView.Entities.First().GetAttributeValue<string>("fetchxml");
				string layoutXml = defaultView.Entities.First().GetAttributeValue<string>("layoutxml");
				string queryApi = defaultView.Entities.First().GetAttributeValue<string>("queryapi") ?? "";

				var excel = Messages.Undocumented.ExportToExcel(service, view, fetchXml, layoutXml, queryApi);

				if (excel != null)
				{
					File.WriteAllBytes("test.xlsx", excel);
				}
				Assert.IsNotNull(excel);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[Test]
		public void RestoreAsync()
		{
			//
			var service = Connection.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
				   Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

			var a = Audits.RestoreDeletedRecord(service, new Guid("F44E78E4-EE29-EE11-A9BB-000D3AA26549"));
		}

		[Test]
		public void ActivateRecord()
		{
			//
			var service = Connection.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
				   Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

			Messages.ActivateRecord(service, "account", new Guid("09859910-8f35-ee11-bdf4-000d3a07e75b"));
		}

		[Test]
		public void SendEmail()
		{
			var service = Connection.ConnectServiceOAuth(Config.CrmConfig.EnvironmentUrl, Config.CrmConfig.ClientId,
				   Config.CrmConfig.UserId, Config.CrmConfig.UserPassword, Config.CrmConfig.TenantId);

			Messages.SendEmail(service, new CrmSdkLibrary.Definition.Email.EmailFormat()
			{
				From = new EntityReferenceEmailRecipient(new EntityReference("systemuser", service.CallerId)),
				To = new StringEmailRecipient[] { new StringEmailRecipient(""), },
				Subject = "this thes",
				Description = @"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
	<title></title>
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
</head>
<body style=""margin: 0; padding: 0;"">
	<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""780"" id=""tbl_body"" style=""font-family: 맑은 고딕;"">
		<tr>
			<td>
				<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""760"" style=""margin-top: 10px; margin-left: 10px; margin-right: 10px; margin-bottom: 10px"">
					<tr>
						<td style=""color:red; font-weight:bold;"">
							
						</td>
					</tr>
					<tr>
						<td height=""5px"" style=""font-size: 1pt""></td>
					</tr>
					<tr>
						<td style=""padding: 3px"">
		 
							<br />
							
						</td>
					</tr>
					<tr>
						<td height=""8px"" style=""font-size: 1pt""></td>
					</tr>
					<tr>
						<td valign=""middle"">
							<div style=""font-size:17px; font-weight:bold;""></div>
						</td>
					</tr>
					<tr>
						<td height=""5px"" style=""font-size: 1px"">&nbsp;</td>
					</tr>
					<tr>
						<td style=""padding: 0px"">
							<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px; border: 1px solid #808080;"">
								<tr>
									<td style=""padding: 0px"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
								
												</td>
												<td width=""262"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080; "">
						
												</td>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080; "">
							
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
								
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">

												</td>
												<td width=""262"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080; "">
						
												</td>
												<td width=""103"" valign=""middle"" align=""center"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
							
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
							
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
						
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
						
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
						
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 2px solid #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" valign=""middle"" bgcolor=""#eeeeee"" style=""background-color: #ebebeb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">&nbsp;</td>
												<td width=""84"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;""></td>
												<td width=""164"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;""></td>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-bottom: 1px solid #808080;""></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-bottom: 1px solid #808080;"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; border-right: 1px solid #808080; padding-left: 3px; padding-right: 3px; padding-top: 0px; padding-bottom: 0px;"">
						
												</td>
												<td style=""padding: 0;"">
													<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0"">
														<tr>
															<td width=""84"" align=""center"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
										
															</td>
															<td width=""164"" align=""right"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
										
															</td>
															<td align=""center"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
							
															</td>
														</tr>
														<tr>
															<td width=""84"" align=""center"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; "">
									
															</td>
															<td width=""164"" align=""right"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; "">
						
															</td>
															<td align=""center"" valign=""middle"" style=""padding: 3px; "">
							
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px;"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
							
												</td>
												<td align=""right"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
				
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 6px double #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px; border-top: 1px solid #808080;"">
											<tr>
												<td width=""103"" valign=""middle"" bgcolor=""#eeeeee"" style=""background-color: #ebebeb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">&nbsp;</td>
												<td width=""84"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">매입유형</td>
												<td width=""164"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">매입액</td>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-bottom: 1px solid #808080;""></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-bottom: 1px solid #808080;"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; border-right: 1px solid #808080; padding-left: 3px; padding-right: 3px; padding-top: 0px; padding-bottom: 0px;"">
				
												</td>
												<td style=""padding: 0;"">
													<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0"">
														<tr>
															<td width=""84"" align=""center"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
										
															</td>
															<td width=""164"" align=""right"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
										
															</td>
															<td align=""center"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
							
															</td>
														</tr>
														<tr>
															<td width=""84"" align=""center"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; "">
									
															</td>
															<td width=""164"" align=""right"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; "">
						
															</td>
															<td align=""center"" valign=""middle"" style=""padding: 3px; "">
							
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
						
												</td>
												<td align=""right"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
							
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 2px solid #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
				
												</td>
												<td align=""right"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
							
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 2px solid #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#212529"" style=""background-color: #212529; color: #ffffff; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
						
												</td>
												<td width=""297"" align=""right"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
							
												</td>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#212529"" style=""background-color: #212529; color: #ffffff; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
						
												</td>
												<td align=""center"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
						
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 2px solid #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
							
												</td>
												<td align=""right"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
							
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 2px solid #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#212529"" style=""background-color: #212529; color: #ffffff; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
						
												</td>
												<td width=""297"" align=""right"" valign=""middle"" style=""padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
							
												</td>
												<td width=""103"" align=""center"" valign=""middle"" bgcolor=""#212529"" style=""background-color: #212529; color: #ffffff; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
								
												</td>
												<td align=""center"" valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">

												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style=""padding: 0px; border-top: 2px solid #808080"">
										<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""margin: 0px;"">
											<tr>
												<td width=""153"" align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
													
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
													
												</td>
											</tr>
											<tr>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
													
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
													
												</td>
											</tr>
											<tr>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
													
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
													
												</td>
											</tr>
											<tr>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
													
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
													
												</td>
											</tr>
											<tr>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080; border-bottom: 1px solid #808080;"">
													
												</td>
												<td valign=""middle"" style=""padding: 3px; border-bottom: 1px solid #808080;"">
												</td>
											</tr>
											<tr>
												<td align=""center"" valign=""middle"" bgcolor=""#dbdbdb"" style=""background-color: #dbdbdb; padding: 3px; border-right: 1px solid #808080;"">
													
												</td>
												<td valign=""middle"" style=""padding: 3px;"">
													
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style=""padding: 0px"">&nbsp;</td>
					</tr>
					<tr>
						<td align=""center"" valign=""middle"" bgcolor=""#0088ec"" style=""background-color: #0088ec; cursor: default;"">
							<a href="""" target=""_blank"" style=""text-decoration: none; cursor: pointer; color: #ffffff; font-size: 16px; line-height: 31px"">
								<b></b>
							</a>
						</td>
					</tr>
					<tr>
						<td height=""3"" style=""padding: 0px; font-size: 1pt""></td>
					</tr>
					<tr>
						<td align=""center"" valign=""middle"" bgcolor=""#b2ccff"" style=""background-color: #b2ccff; cursor: default;"">
							<a href="""" target=""_blank"" style=""text-decoration: none; cursor: pointer; color: #000000; font-size: 16px; line-height: 31px"">
								
							</a>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</body>
</html>
"
			});
		}
	}
}