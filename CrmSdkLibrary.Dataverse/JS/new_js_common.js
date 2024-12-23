﻿var $ = parent.$;
var _formContext;
var _queryString;
const globalContext = (window.Xrm != undefined ? Xrm.Utility.getGlobalContext() : null);
var FORM_TYPE_CREATE = 1;
var FORM_TYPE_UPDATE = 2;
var FORM_TYPE_READONLY = 3;
var mutationObs = null;

Object.defineProperty(this, 'formContext', {
	get: function () { return _formContext; },
	set: function (v) {
		_formContext = v;

		// Initialize formcontext properties
		if (_formContext.zerglrisk == undefined) {
			_formContext.zerglrisk = {
				debug: {},
				webApi: {},
			};
		}

		try {
			const makeHttpRequest = (method, url, isAsync = true) => {
				// 동기 요청일 경우
				if (!isAsync) {
					const req = new XMLHttpRequest();
					req.open(method, url, false); // 동기 호출
					req.setRequestHeader("Accept", "application/json");
					req.setRequestHeader("OData-MaxVersion", "4.0");
					req.setRequestHeader("OData-Version", "4.0");
					req.setRequestHeader("Prefer", "odata.include-annotations=*");

					try {
						req.send();
						if (req.status >= 200 && req.status < 300) {
							return {
								data: JSON.parse(req.response),
								status: req.status
							};
						} else {
							const error = JSON.parse(req.response).error;
							console.log(error.message);
							throw {
								status: req.status,
								statusText: error.message
							};
						}
					} catch (error) {
						console.error(error);
						return null;
					}
				}

				// 비동기 요청일 경우
				return new Promise((resolve, reject) => {
					const req = new XMLHttpRequest();
					req.open(method, url, true);
					req.setRequestHeader("Accept", "application/json");
					req.setRequestHeader("OData-MaxVersion", "4.0");
					req.setRequestHeader("OData-Version", "4.0");
					req.setRequestHeader("Prefer", "odata.include-annotations=*");

					req.onload = function () {
						if (this.status >= 200 && this.status < 300) {
							resolve({
								data: JSON.parse(req.response),
								status: this.status
							});
						} else {
							const error = JSON.parse(req.response).error;
							console.log(error.message);
							reject({
								status: this.status,
								statusText: error.message
							});
						}
					};

					req.onerror = function () {
						reject({
							status: this.status,
							statusText: req.statusText
						});
					};

					req.send();
				});
			};

			// Debug functions group
			const initializeDebugFunctions = () => {
				_formContext.zerglrisk.debug.openByGuid = function (entityName, entityId, width, height) {
					var guid = formContext.data.entity.getEntityReference().id;
					guid = guid.replace("{", "").replace("}", "").toString();

					//var loc = window.location;
					//var crmurl = loc.protocol + "//" + loc.host + loc.pathname;
					if (entityName == null) {
						entityName = prompt("Enter the records entity internalname (ex; account, new_contact)",
							formContext.data.entity.getEntityName());
					}

					//var etcetn = Number.isInteger(entity) ? "?etc=" : "?etn=";
					if (entityId == null) {
						entityId = prompt("Enter the records GUID", guid);
					}

					//var fullurl = crmurl + etcetn + entityName + "&id=" + entityId + "&pagetype=entityrecord";
					//console.log("Opening " + fullurl);
					//window.open(fullurl, "_blank");

					var formItem = formContext.ui.formSelector.getCurrentItem();
					var parameters = {};
					var entityFormOptions = {
						entityName: entityName,
						useQuickCreateForm: false,
						openInNewWindow: true,
						entityId: entityId,
						formId: (formItem != null ? formItem.getId() : null),
						width: (width != null ? width : 950),
						height: (height != null ? height : 600)
					};

					Xrm.Navigation.openForm(entityFormOptions, parameters).then(
						function (e) {
							console.log(e);
						},
						function (error) {
							console.log(error);
						}
					);
				};

				_formContext.zerglrisk.debug.openCopyForm = function (entityName, entityId, width, height) {
					var guid = formContext.data.entity.getEntityReference().id;
					guid = guid.replace("{", "").replace("}", "").toString();

					// var entityReference = {
					// entityType: "new_teamschedule",
					// id: guid
					// };
					//
					// var params = {};
					// OpenNewWindowCopyForm('new_teamschedule', params, entityReference, 950, 600, GetCurrentFormId(), function () { }, function (error) { });
					if (entityName == null) {
						entityName = prompt("Enter the records entity internalname (ex; account, new_contact)",
							formContext.data.entity.getEntityName());
					}

					//var etcetn = Number.isInteger(entity) ? "?etc=" : "?etn=";
					if (entityId == null) {
						entityId = prompt("Enter the records GUID", guid);
					}

					var formItem = formContext.ui.formSelector.getCurrentItem();
					var parameters = {};
					var entityFormOptions = {
						entityName: entityName,
						useQuickCreateForm: false,
						openInNewWindow: true,
						createFromEntity: { entityType: entityName, id: entityId },
						formId: (formItem != null ? formItem.getId() : null),
						width: (width != null ? width : 950),
						height: (height != null ? height : 600)
					};

					Xrm.Navigation.openForm(entityFormOptions, parameters).then(
						function (e) {
							console.log(e);
						},
						function (error) {
							console.log(error);
						}
					);
				};

				_formContext.zerglrisk.debug.getEntityTypeCodeSync = async function (entityName) {
					if (entityName == null) {
						entityName = prompt("Enter the records entity internalname (ex; account, new_contact)",
							formContext.data.entity.getEntityName());
					}
					var objectTypeCode = null;

					//Getting entity Metadata to get otc (Object Type Code)
					await Xrm.Utility.getEntityMetadata(entityName).then(
						function (entityMetadata) {
							objectTypeCode = entityMetadata.ObjectTypeCode;
						});

					return objectTypeCode;
				};
			};

			// WebApi functions group
			const initializeWebApiFunctions = () => {
				_formContext.zerglrisk.webApi.getEntityMetadata = function (entityLogicalName, successCallback, errorCallback) {
					if (entityLogicalName == undefined || entityLogicalName === "") {
						entityLogicalName = formContext.data.entity.getEntityName();
					}

					//Getting entity Metadata to get otc (Object Type Code)
					Xrm.Utility.getEntityMetadata(entityLogicalName).then(successCallback, errorCallback);
				};

				_formContext.zerglrisk.webApi.setStatus = function (statecode, statuscode, successCallBack, errorCallBack) {
					var entityLogicalName = _formContext.data.entity.getEntityName();

					// Remove brackets from the GUID if there’s any
					var id = _formContext.data.entity.getEntityReference().id.replace("{", "").replace("}", "").toString();

					// Set statecode and statuscode
					var data = {
						"statecode": statecode,
						"statuscode": statuscode
					};

					if (successCallBack == null) {
						successCallBack = function success(result) {
							_formContext.data.refresh(false);
						};
					}
					if (errorCallBack == null) {
						errorCallBack = function (error) {
							_formContext.data.refresh(false);
						};
					}

					Xrm.WebApi.updateRecord(entityLogicalName, id, data).then(successCallBack, errorCallBack);
				};

				_formContext.zerglrisk.webApi.update = function (data, successCallBack, errorCallBack) {
					var entityLogicalName = _formContext.data.entity.getEntityName();

					// Remove brackets from the GUID if there’s any
					var id = _formContext.data.entity.getEntityReference().id.replace("{", "").replace("}", "").toString();
					Xrm.WebApi.updateRecord(entityLogicalName, id, data).then(successCallBack, errorCallBack);
				};

				//Must have imageblob/{id}  api on customApiUrl
				_formContext.zerglrisk.webApi.replaceImageBlobToCustomAPI = function (fieldid, customApiUrl) {
					if (!_formContext.getAttribute(fieldid)) {
						console.error("[new_js_common] UpdateImageBlob : cannot find '" + fieldid + "' field.");
						return null;
					}

					//괄호 포함 /\((.*?)\)/g
					//괄호 미포함 /(?<=\().+?(?=\))/g
					var template = document.createElement("div");
					var replaceStr = _formContext.getAttribute(fieldid).getValue();
					template.innerHTML = replaceStr.trim();
					var imgs = template.getElementsByTagName("img");

					for (var i = 0; i < imgs.length; ++i) {
						if (imgs[i].src.indexOf('msdyn_richtextfiles') == -1) {
							continue;
						}

						var regx = /\((.*?)\)/g;
						var m = regx.exec(imgs[i].src);
						var targetId = m[0].replace("(", "").replace(")", "");
						console.log(targetId);

						//수정필요 src부분의 XXX/api XXX부분 삭제(http:///불라불라 호스트)
						// customApiUrl ; https://blabla.com/api/Content/imageblob/
						replaceStr = replaceStr.replace(imgs[i].src.replace(window.top.window.location.origin, ''), customApiUrl + targetId);
					}

					return replaceStr;
				};

				_formContext.zerglrisk.webApi.retrieveGlobalOptionSets = function (optionsetName) {
					var data = null;
					var req = new XMLHttpRequest();
					req.open('GET', Xrm.Page.context.getClientUrl() + "/api/data/v9.0/GlobalOptionSetDefinitions(Name='" + optionsetName + "')", false);
					req.setRequestHeader("Accept", "application/json");
					req.setRequestHeader("OData-MaxVersion", "4.0");
					req.setRequestHeader("OData-Version", "4.0");
					req.setRequestHeader("Prefer", "odata.include-annotations=*");
					req.send();
					if (req.readyState == 4 /* complete */) {
						if (req.status == 200) {
							data = JSON.parse(req.response);
						} else {
							var error = JSON.parse(req.response).error;
							console.log(error.message);
						}
					}
					return data;
				};


				// usage : RetrieveGlobalOptionSetsAsync('new_p_calltype2').then(function (a){ console.log(a);}).catch(function(err){ console.log(err);});
				_formContext.zerglrisk.webApi.retrieveGlobalOptionSetsAsync = function (optionsetName) {
					return new Promise(function (resolve, reject) {
						var req = new XMLHttpRequest();
						req.open('GET', Xrm.Page.context.getClientUrl() + "/api/data/v9.0/GlobalOptionSetDefinitions(Name='" + optionsetName + "')");
						req.setRequestHeader("Accept", "application/json");
						req.setRequestHeader("OData-MaxVersion", "4.0");
						req.setRequestHeader("OData-Version", "4.0");
						req.setRequestHeader("Prefer", "odata.include-annotations=*");
						req.onload = function () {
							if (this.status >= 200 && this.status < 300) {
								resolve(JSON.parse(req.response));
							} else {
								var error = JSON.parse(req.response).error;
								reject({
									status: this.status,
									statusText: error.message,
								});
								console.log(error.message);
							}
						};
						req.onerror = function () {
							reject({
								status: this.status,
								statusText: req.statusText
							});
						};
						req.send();
					});
				};

				//Query Must startwith '?'
				// Using RetrieveEntityManyToManyRelationshipRecordsAsync('teams','10b9fbe0-fa54-e911-a988-000d3aa37980','teammembership_association','');
				// Using RetrieveEntityManyToManyRelationshipRecordsAsync('systemusers','dae9b66d-4610-ec11-b6e6-000d3a82ed38','new_new_salesoffice_systemuser','?$select=new_name&$filter=new_chk_useincalendar eq true&$orderby=new_i_order');
				_formContext.zerglrisk.webApi.retrieveEntityManyToManyRelationshipRecordsAsync = function (entitySetName, entityRecordId, relationshipSchemaName, query) {
					return new Promise(function (resolve, reject) {
						var req = new XMLHttpRequest();
						req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/${entitySetName}(${entityRecordId})/${relationshipSchemaName}${(query ? query : '')}`);
						req.setRequestHeader("Accept", "application/json");
						req.setRequestHeader("OData-MaxVersion", "4.0");
						req.setRequestHeader("OData-Version", "4.0");
						req.setRequestHeader("Prefer", "odata.include-annotations=*");
						req.onload = function () {
							if (this.status >= 200 && this.status < 300) {
								resolve(JSON.parse(req.response));
							} else {
								var error = JSON.parse(req.response).error;
								reject({
									status: this.status,
									statusText: error.message,
								});
								console.log(error.message);
							}
						};
						req.onerror = function () {
							reject({
								status: this.status,
								statusText: req.statusText
							});
						};
						req.send();
					});
				};

				_formContext.zerglrisk.webApi.retrieveAttributeMetadataAsync = function (entityLogicalName, attributeName) {
					return new Promise(function (resolve, reject) {
						var req = new XMLHttpRequest();
						req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/EntityDefinitions(LogicalName='${entityLogicalName}')/Attributes(LogicalName='${attributeName}')`);
						req.setRequestHeader("Accept", "application/json");
						req.setRequestHeader("OData-MaxVersion", "4.0");
						req.setRequestHeader("OData-Version", "4.0");
						req.setRequestHeader("Prefer", "odata.include-annotations=*");
						req.onload = function () {
							if (this.status >= 200 && this.status < 300) {
								var jobj = JSON.parse(req.response);
								if (jobj && jobj["@odata.type"]) {
									_formContext.zerglrisk.webApi.retrieveAttributeMetadataDetailAsync(entityLogicalName, attributeName, jobj["@odata.type"]).then(function (results) {
										try {
											resolve(results);
										} catch (error) {
											reject({
												status: this.status,
												statusText: error.message,
											});
										}
									}).catch(function (err) {
										reject({
											status: this.status,
											statusText: err.message,
										});
									});
								} else {
									resolve(jobj);
								}
							} else {
								var error = JSON.parse(req.response).error;
								reject({
									status: this.status,
									statusText: error.message,
								});
								console.log(error.message);
							}
						};
						req.onerror = function () {
							reject({
								status: this.status,
								statusText: req.statusText
							});
						};
						req.send();
					});
				};

				_formContext.zerglrisk.webApi.retrieveAttributeMetadataDetailAsync = function (entityLogicalName, attributeName, odataType) {
					return new Promise(function (resolve, reject) {
						if (!odataType) {
							reject({
								status: 0,
								statusText: '@odata.type value is Empty.'
							});
							return;
						}

						var expand = '';
						if (odataType == '#Microsoft.Dynamics.CRM.PicklistAttributeMetadata') {
							expand = '?$expand=OptionSet($select=Options),GlobalOptionSet($select=Options)';
							//또는 바로 Optionset만 가져오도록 /OptionSet?$select=Options 해도 됨
						} else if (odataType == '#Microsoft.Dynamics.CRM.BooleanAttributeMetadata') {
							expand = '?$expand=GlobalOptionSet($select=FalseOption,TrueOption)';
							//GlobalOptionSet Only
						}

						var odataTpyeQuery = `/${odataType.replace('#', '')}${expand}`;
						var req = new XMLHttpRequest();
						req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/EntityDefinitions(LogicalName='${entityLogicalName}')/Attributes(LogicalName='${attributeName}')${odataTpyeQuery}`);
						req.setRequestHeader("Accept", "application/json");
						req.setRequestHeader("OData-MaxVersion", "4.0");
						req.setRequestHeader("OData-Version", "4.0");
						req.setRequestHeader("Prefer", "odata.include-annotations=*");
						req.onload = function () {
							if (this.status >= 200 && this.status < 300) {
								resolve(JSON.parse(req.response));
							} else {
								var error = JSON.parse(req.response).error;
								reject({
									status: this.status,
									statusText: error.message,
								});
								console.log(error.message);
							}
						};
						req.onerror = function () {
							reject({
								status: this.status,
								statusText: req.statusText
							});
						};
						req.send();
					});
				};

				_formContext.zerglrisk.webApi.retrieveEntityRelationshipMetadataAsync = function (entityLogicalName, RelationshipType, SchemaName) {
					return new Promise(function (resolve, reject) {
						if (RelationshipType !== 'OneToManyRelationships' && RelationshipType !== 'ManyToManyRelationships' && RelationshipType !== 'ManyToOneRelationships') {
							reject({
								status: 0,
								statusText: 'Unknown RelationshipType.',
							});
							return;
						}

						var schemaNameQuery = SchemaName ? `(SchemaName='${SchemaName}')` : '';

						var req = new XMLHttpRequest();
						req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/EntityDefinitions(LogicalName='${entityLogicalName}')/${RelationshipType}${schemaNameQuery}`);
						req.setRequestHeader("Accept", "application/json");
						req.setRequestHeader("OData-MaxVersion", "4.0");
						req.setRequestHeader("OData-Version", "4.0");
						req.setRequestHeader("Prefer", "odata.include-annotations=*");
						req.onload = function () {
							if (this.status >= 200 && this.status < 300) {
								var jobj = JSON.parse(req.response);
								if (jobj && jobj["@odata.type"]) {
									_formContext.zerglrisk.webApi.retrieveAttributeMetadataDetailAsync(entityLogicalName, attributeName, jobj["@odata.type"]).then(function (results) {
										try {
											resolve(results);
										} catch (error) {
											reject({
												status: this.status,
												statusText: error.message,
											});
										}
									}).catch(function (err) {
										reject({
											status: this.status,
											statusText: err.message,
										});
									});
								} else {
									resolve(jobj);
								}
							} else {
								var error = JSON.parse(req.response).error;
								reject({
									status: this.status,
									statusText: error.message,
								});
								console.log(error.message);
							}
						};
						req.onerror = function () {
							reject({
								status: this.status,
								statusText: req.statusText
							});
						};
						req.send();
					});
				};

				// usage : RetrieveGlobalOptionSetsAsync('new_p_calltype2').then(function (a){ console.log(a);}).catch(function(err){ console.log(err);});
				_formContext.zerglrisk.webApi.getHighlightFromTimeline = function (entityLogicalName) {
					return new Promise(function (resolve, reject) {
						var req = new XMLHttpRequest();
						req.open('GET', Xrm.Page.context.getClientUrl() + "/api/data/v9.0/new_projects_skecs('" + entityLogicalName + "')/timeline");
						req.setRequestHeader("Accept", "application/json");
						req.setRequestHeader("OData-MaxVersion", "4.0");
						req.setRequestHeader("OData-Version", "4.0");
						req.setRequestHeader("Prefer", "odata.include-annotations=*");
						req.onload = function () {
							if (this.status >= 200 && this.status < 300) {
								resolve(JSON.parse(req.response));
							} else {
								var error = JSON.parse(req.response).error;
								reject({
									status: this.status,
									statusText: error.message,
								});
								console.log(error.message);
							}
						};
						req.onerror = function () {
							reject({
								status: this.status,
								statusText: req.statusText
							});
						};
						req.send();
					});
				};
			};

			// Utility functions group
			const initializeUtilityFunctions = () => {
				_formContext.zerglrisk.openWebResourceDialog = function (data, width, height, isSide, webresourceName) {
					if (data == null) {
						console.log("[new_js_common] OpenWebResourceDialog : not provide data parameter.(required)");
						return;
					}
					if (width == null) {
						width = { value: 50, unit: "%" };
					}
					var position = isSide ? 2 : 1;
					if (webresourceName == null || webresourceName == "") {
						webresourceName = "new_u_html_dialog_template";
					}
					Xrm.Navigation.navigateTo(
						{ pageType: "webresource", webresourceName: webresourceName, data: data },
						{ target: 2, position: position, width: width, height: height }
					);
				};

				//only for UCI
				//field tag generate 되기 전에 미리 dom ID를 알 수 있다. mutation observer를 사용하여 필드가 load 되었는지 감시할 때 사용 가능
				_formContext.zerglrisk.getDomId = function (fieldId) {
					if (fieldId == null || fieldId == "") {
						return null;
					}
					return _formContext.getControl(fieldId).controlDescriptor.DomId;
				};

				//you can find element using data-id="ParentSectionName" 
				_formContext.zerglrisk.getParentSectionName = function (fieldId) {
					if (fieldId == null || fieldId == "") {
						return null;
					}
					return _formContext.getControl(fieldId).controlDescriptor.ParentSectionName;
				}

				_formContext.zerglrisk.getCurrentFormId = function () {
					var formItem = formContext.ui.formSelector.getCurrentItem();
					return (formItem != null ? formItem.getId() : null);
				};

				// For Field Observer (Deprecated)
				_formContext.zerglrisk.registerFieldObserver = function (attributeName, eventCallback) {
					if (typeof eventCallback != 'function') {
						return;
					}
					if (_formContext.getControl(attributeName) == undefined) {
						return;
					}

					let observer = {
						update: eventCallback
					};

					formContext.getControl('new_l_l1').controlStateObservable.registerObserver(observer);
				};

				//only for subgrid in uci ( not work even set on form editor )
				// Deprecated, Rederning Order Changed. (if want fix it, use mutationobserver that you can spying grid render time.)
				_formContext.zerglrisk.setSubGridHeaderColor = function (subGridId) {
					if (subGridId == null || subGridId == "") {
						return;
					}

					var a = true;

					// FIXME : Deprecated.
					if (a)
						return;

					_formContext.getControl(subGridId).addOnLoad(function (element) {

						//console.log(this.name + "loaded");
						if (element.getEventSource == undefined) {

							//not uci
							console.error("[new_js_common] SetSubGridHeaderColor : Cannot find EventSource");
							return;
						}

						// only for UCI
						// only for subgrid in addOnLoad event
						function GetSubGridHeadrColor(element) {
							parameters = element.getEventSource().controlDescriptor.Parameters;
							if (parameters == undefined || parameters == null) {
								return null;
							}
							if (parameters.HeaderColorCode == undefined || parameters.HeaderColorCode == null) {
								return null;
							}

							return element.getEventSource().controlDescriptor.Parameters.HeaderColorCode;
						}

						// only for UCI
						// only for subgrid in addOnLoad event
						function GetLabelParentElement(element) {
							var target = window.top.document.getElementById(element.getEventSource().controlDescriptor.DomId).closest("[id$=" + element.getEventSource().controlDescriptor.Id + "]");

							// Label Element
							//return Array.from(target.querySelectorAll('div')).find(el => el.children.length === 0 && el.textContent === element.getEventSource().controlDescriptor.Label);
							// Label Parent Element
							//return Array.from(target.querySelectorAll('div')).find(el => el.textContent === element.getEventSource().controlDescriptor.Label);
							//-> IE에서 find folyfill해도 es2015 안먹혀서 변경
							function findtextContent(el) {
								return el.textContent === element.getEventSource().controlDescriptor.Label;
							}
							return Array.from(target.querySelectorAll('div')).find(findtextContent);
						}

						var target = GetLabelParentElement(element);
						if (target != undefined) {
							target.style.background = GetSubGridHeadrColor(element);
						}

						//element.getEventSource().controlDescriptor.Parameters.ViewId
						//element.getEventSource().controlDescriptor.DomId

						//var target = window.parent.document.getElementById("dataSetRoot_sub_Competitor");
						//if (target != undefined)
						//var childNode = target.childNodes[0];
						//if (childNode != undefined) {
						//    childNode.style.background = "#EC7063";
						//}
					});
				};

				_formContext.zerglrisk.initializedNoteTemplateAll = function (templateHtml) {
					var target = parent.document.querySelector('#mainContent');
					if (target == undefined || target == null) {
						console.error("[new_js_common] Cannot Find Target.");
						return;
					}

					var entityName;
					try {
						entityName = Xrm.Page.data.entity.getEntityName();
					} catch (error) {
						console.error('[new_js_common] Failed to getting entity name');
						return;
					}

					if (!templateHtml || templateHtml == '') {
						console.warn('[new_js_common] templateHtml is required. cannot be set empty');
					}

					var prevNode;
					const observer = new MutationObserver((mutations) => {
						mutations.forEach((mutation) => {
							mutation.addedNodes.forEach((node) => {
								if (node.nodeType === 1) {
									if (node.outerHTML == '<p><br data-cke-filter="true"></p>' && prevNode) {
										// if (prevNode && prevNode.innerHTML.indexOf(node.outerHTML) > -1) { // Find CK Editor data;
										// '<p><br data-cke-filter="true"></p>' means CK Editor on create (in editor.getData() == '')
										// checked on 2024-11-12
										const editorDiv = prevNode.querySelector('div.ck.ck-content');

										if (editorDiv) {
											const editor = editorDiv.ckeditorInstance;
											if (editor?.getData() == '') {
												editor?.setData(templateHtml);
											}
											prevNode = null;
										}
									}

									if (node.getAttribute('data-lp-id') == `MscrmControls.RichTextEditorV2.RichTextEditorControlV2|notescontrol.RichTextEditorControl_Container|${entityName}`) {
										//if (node.getAttribute('data-lp-id)?.split('|').includes(entityName)) {
										prevNode = node;
									}
								}
							})
						});
					});

					const config = {
						childList: true,
						subtree: true
					};

					observer.observe(target, config);

					return observer;
				}

				// Observing Parent Secetion
				_formContext.zerglrisk.initializedNoteTemplateParentSection = function (templateHtml, fieldTarget) {
					if (!fieldTarget || fieldTarget == '') {
						console.error("[new_js_common] fieldTarget is required.");
						return;
					}

					// fieldTarget이 attribute name인지 domId인지 getDomId 결과로 확인
					//const domId = _formContext.zerglrisk.getDomId(fieldTarget);
					const parentSectionName = _formContext.zerglrisk.getParentSectionName(fieldTarget);

					//if (!domId) {
					//	console.error("[new_js_common] Cannot find DOM ID. Please check if the field exists in the form.");
					//	return;
					//}

					// Waiting Target Field html code generate.
					const findTarget = (parentSectionName) => {
						return new Promise((resolve, reject) => {
							const findElement = () => {
								const target = parent?.document.querySelector(`[data-id="${parentSectionName}"]`) ?? window.top.document.querySelector(`[data-id="${parentSectionName}"]`);
								if (target) {
									resolve(target);
								} else {
									setTimeout(findElement, 1000);
								}
							};
							findElement();
						});
					};

					findTarget(parentSectionName).then(target => {
						if (!target) {
							console.error("[new_js_common] Cannot Find Target.");
							return;
						}

						let entityName;
						try {
							entityName = Xrm.Page.data.entity.getEntityName();
						} catch (error) {
							console.error('[new_js_common] Failed to getting entity name');
							return;
						}

						if (!templateHtml || templateHtml == '') {
							console.warn('[new_js_common] templateHtml is required. cannot be set empty');
							return;
						}

						let prevNode;
						const observer = new MutationObserver((mutations) => {
							mutations.forEach((mutation) => {
								mutation.addedNodes.forEach((node) => {
									if (node.nodeType === 1) {
										if (prevNode && prevNode.innerHTML.indexOf(node.outerHTML) > -1) { // Find CK Editor data;
											const editorDiv = prevNode.querySelector('div.ck.ck-content');
											if (editorDiv) {
												const editor = editorDiv.ckeditorInstance;
												if (editor?.getData() == '') {
													editor?.setData(templateHtml);
												}
												prevNode = null;
											}
										}
										if (node.getAttribute('data-lp-id') == `MscrmControls.RichTextEditorV2.RichTextEditorControlV2|notescontrol.RichTextEditorControl_Container|${entityName}`) {
											prevNode = node;
										}
									}
								});
							});
						});

						const config = {
							childList: true,
							subtree: true
						};

						observer.observe(target, config);
						return observer;
					}).catch(error => {
						console.error('[new_js_common] Error finding target:', error);
					});
				};

				// Not work
				_formContext.zerglrisk.initializedNoteTemplate = function (templateHtml, fieldTarget = null) {
					if (!fieldTarget) {
						console.error("[new_js_common] fieldTarget is required. Please provide field name.");
						return;
					}

					let domId = fieldTarget;
					if (fieldTarget) {
						const getDomIdResult = _formContext.zerglrisk.getDomId(fieldTarget);
						if (getDomIdResult) {
							domId = getDomIdResult;
						}
					}

					if (!domId) {
						console.error("[new_js_common] Cannot find DOM ID. Please check if the field exists in the form.");
						return;
					}

					let entityName;
					try {
						entityName = Xrm.Page.data.entity.getEntityName();
					} catch (error) {
						console.error('[new_js_common] Failed to getting entity name');
						return;
					}

					if (!templateHtml || templateHtml == '') {
						console.warn('[new_js_common] templateHtml is required. cannot be set empty');
						return;
					}

					// DOM에서 target이 제거되거나 변경되는 것을 감시하기 위한 상위 observer
					const parentObserver = new MutationObserver((mutations) => {
						mutations.forEach(() => {
							const currentTarget = document.querySelector(`#${domId}`) || parent?.document.querySelector(`#${domId}`) || window.top.document.querySelector(`#${domId}`); // domId에 #추가
							if (currentTarget && !currentTarget.dataset.observing) {
								startChildObserver(currentTarget);
							}
						});
					});

					function startChildObserver(target) {
						if (target.dataset.observing === 'true') return;

						target.dataset.observing = 'true';
						console.log('[new_js_common] Starting observer for field:', fieldTarget);

						let prevNode;
						const childObserver = new MutationObserver((mutations) => {
							mutations.forEach((mutation) => {
								mutation.addedNodes.forEach((node) => {
									if (node.nodeType === 1) {
										// CKEditor 초기화 감지 - 해당 필드의 노트에만 적용
										if (node.outerHTML == '<p><br data-cke-filter="true"></p>' && prevNode) {
											const editorDiv = prevNode.querySelector('div.ck.ck-content');
											if (editorDiv && editorDiv.closest(`#${domId}`)) {  // 해당 필드 내부인지 확인
												const editor = editorDiv.ckeditorInstance;
												if (editor?.getData() == '') {
													console.log('[new_js_common] Setting template data for field:', fieldTarget);
													editor?.setData(templateHtml);
												}
												prevNode = null;
											}
										}

										// RichTextEditor 컨테이너 감지 - 해당 필드의 것만
										if (node.getAttribute('data-lp-id') == `MscrmControls.RichTextEditorV2.RichTextEditorControlV2|notescontrol.RichTextEditorControl_Container|${entityName}`
											&& node.closest(`#${domId}`)) {
											prevNode = node;
										}
									}
								});
							});
						});

						const config = {
							childList: true,
							subtree: true
						};

						childObserver.observe(target, config);

						target.addEventListener('DOMNodeRemoved', () => {
							console.log('[new_js_common] Field target removed, disconnecting observer:', fieldTarget);
							childObserver.disconnect();
							target.dataset.observing = 'false';
						});
					}

					const findAndObserveTarget = () => {
						const target = document.querySelector(`#${domId}`) || parent?.document.querySelector(`#${domId}`) || window.top.document.querySelector(`#${domId}`);
						if (target) {
							console.log('[new_js_common] Initial field target found:', fieldTarget);
							startChildObserver(target);

							parentObserver.observe(target.parentElement, {
								childList: true,
								subtree: true
							});
						} else {
							console.log('[new_js_common] Field target not found, retrying...:', fieldTarget);
							setTimeout(findAndObserveTarget, 1000);
						}
					};

					findAndObserveTarget();

					return {
						disconnect: () => {
							parentObserver.disconnect();
							const target = document.querySelector(`#${domId}`) || parent?.document.querySelector(`#${domId}`) || window.top.document.querySelector(`#${domId}`);
							if (target) {
								target.dataset.observing = 'false';
							}
						}
					};
				};
			};

			// Initialize all function groups
			initializeDebugFunctions();
			initializeWebApiFunctions();
			initializeUtilityFunctions();

		} catch (error) {
			console.error("[new_js_common] Failed to initialize formContext functions:", error);
			console.error(error.stack);
		}

		// Make formContext accessible globally
		window.top.formContext = _formContext;
		console.log("[new_js_common] Defined formContext from new_js_common to window.top");
	}
});

// https://tc39.github.io/ecma262/#sec-array.prototype.find
if (!Array.prototype.find) {
	Object.defineProperty(Array.prototype, 'find', {
		value: function (predicate) {

			// 1. Let O be ? ToObject(this value).
			if (this == null) {
				throw new TypeError('"this" is null or not defined');
			}

			var o = Object(this);

			// 2. Let len be ? ToLength(? Get(O, "length")).
			var len = o.length >>> 0;

			// 3. If IsCallable(predicate) is false, throw a TypeError exception.
			if (typeof predicate !== 'function') {
				throw new TypeError('predicate must be a function');
			}

			// 4. If thisArg was supplied, let T be thisArg; else let T be undefined.
			var thisArg = arguments[1];

			// 5. Let k be 0.
			var k = 0;

			// 6. Repeat, while k < len
			while (k < len) {

				// a. Let Pk be ! ToString(k).
				// b. Let kValue be ? Get(O, Pk).
				// c. Let testResult be ToBoolean(? Call(predicate, T, « kValue, k, O »)).
				// d. If testResult is true, return kValue.
				var kValue = o[k];
				if (predicate.call(thisArg, kValue, k, o)) {
					return kValue;
				}

				// e. Increase k by 1.
				k++;
			}

			// 7. Return undefined.
			return undefined;
		},
		configurable: true,
		writable: true
	});
}


Object.defineProperty(this, 'queryString', {
	get: function () { return _queryString; },
	set: function (v) {
		_queryString = v;
	}
});

//closest IE not support, so register that
if (window.Element && !Element.prototype.closest) {
	Element.prototype.closest = function (s) {
		var matches = (this.document || this.ownerDocument).querySelectorAll(s),
			i,
			el = this;
		do {
			i = matches.length;
			while (--i >= 0 && matches.item(i) !== el) { };
		} while ((i < 0) && (el = el.parentElement));
		return el;
	};
}

// formContext Load용
// Usage : Form Properties의 이벤트 처리기 에서 이벤트 OnLoad에 해당 함수 loadContext 추가 시
// 하단의 함수로 전달되는 쉼표로 구분되는 매개 변수 목록에서 "new_js_account", "OnLoad" 로 추가하면 각각 onLoadTarget, onLoadFunctionName에 바인딩 됨
// 절대로 onLoadFunctionName에 new_js_common 외 다른 먼저 Load되는 js와 겹치는 function명 금지
function loadContext(executionContext, onLoadTarget, onLoadFunctionName) {
	formContext = executionContext.getFormContext();
	queryString = Xrm.Utility.getGlobalContext().getQueryStringParameters();

	// 이 파일 이후에 onLoad되는 script 자동 실행
	if (onLoadTarget) {
		var targetWindow = findContentWindow(onLoadTarget);
		if (targetWindow) {
			const functionName = (onLoadFunctionName && onLoadFunctionName != '') ? onLoadFunctionName : '_onLoad';

			if (typeof targetWindow[functionName] === 'function') {
				targetWindow[functionName](executionContext);
			}
		}
	}
	formContext.zerglrisk.initializedNoteTemplate('<p>테스트</p>', 'Timeline');
}

function findContentWindow(scriptFileName) {
	if (scriptFileName == null || scriptFileName == '') {
		return;
	}

	const documents = parent.document.querySelectorAll('[id^="ClientApiFrame_"]');

	for (var i = 0; i < documents.length; i++) {
		const scripts = documents[i].contentWindow.document.getElementsByTagName('script');

		for (var j = 0; j < scripts.length; j++) {
			if (scripts[j].src != null && scripts[j].src.indexOf(scriptFileName) !== -1) {
				return documents[i].contentWindow;
			}
		}
	}

	return null;
}

//룩업필드 값 세팅
function SetLookupValue(fieldName, id, name, entityType) {
	if (fieldName != null) {
		var lookupValue = new Array();
		lookupValue[0] = new Object();
		lookupValue[0].id = id;
		lookupValue[0].name = name;
		lookupValue[0].entityType = entityType;
		formContext.data.entity.attributes.get(fieldName).setValue(lookupValue);
	}
}

//커스텀 룩업 필드 필터링 함수
function setCLookupFilter(FieldName) {
	formContext.getControl("new_l_" + FieldName).addPreSearch(eval("Sdk." + FieldName + "Filter"));
}

//기본 룩업 필드 필터링 함수
function setDLookupFilter(FieldName) {
	formContext.getControl(FieldName).addPreSearch(eval("Sdk." + FieldName + "Filter"));
}

//날짜필드에 오늘날짜를 자동셋팅해주는 함수
function setToday(FieldName) {
	var DT = new Date();
	formContext.getAttribute(FieldName).setValue(DT);
}

function InitializeLoadingPanel() {
	if ($("body").find("#panel").length > 0) {
		return;
	}

	var displayText = "Copy Quote...";

	// Loading Panel
	$('body').append('<div id="panel"></div>');

	// Loading Panel Content Div
	$('body').append('<div id="contentDiv"></div>');

	$("#panel").hide().css({ 'position': 'absolute', 'top': '0', 'left': '0', 'width': '100%', 'height': '100%', 'background-color': '#FFFFFF', 'opacity': '0.5' });

	$("#contentDiv").append(`<img id="loading" src="${Xrm.Page.context.getClientUrl()}/WebResources/new_gif_progress" style="width:45px; height:45px;" />`).hide();

	//.css({ 'background-color': '#DDDDDD', 'height': '100px', 'width': '300px' });

	// Setup your text css
	//$("#loadingText").css({ "text-align": "center", "margin-top": "50px", "font": "12px bold" });
}

// Open the Loading Panel
function OpenLoadingPanel() {

	// Make sure you Initialize the loading panel
	if ($("body").find("#panel").length <= 0) {
		InitializeLoadingPanel();
	}

	//InitializeLoadingPanel();
	var panel = $("#panel");
	var panelContent = $("#contentDiv");
	var pageHeight = $(document).height();
	var pageWidth = $(window).width();

	panelContent.css("position", "absolute");
	panelContent.css("top", ((pageHeight - panelContent.outerHeight()) / 2) + "px");
	panelContent.css("left", ((pageWidth - panelContent.outerWidth()) / 2) + "px");

	panel.css({ "z-index": 1000 });
	panelContent.css("z-index", 1001);

	panel.fadeTo("fast", 0.8, function () {
		panelContent.fadeIn(10);
	});
}

// Close the Loading Panel by hiding it
function CloseLoadingPanel() {
	$("#contentDiv").fadeOut("fast", function () {
		$("#panel").fadeOut(0, function () {
			$("#contentDiv").hide();
		});
	});
	$("#panel").remove();
	$("#contentDiv").remove();
}

//URL 파라미터 조회
function getURLParameter(name) {
	return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || "";
}

function getURLParameters() {
	var params = {};
	window.location.search.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (str, key, value) { params[key] = value; });
	return params;
}

//필드 잠금
function SetFieldLock(fieldname, diabled) {
	formContext.getControl(fieldname).setDisabled(diabled);
}

//생성폼 여부
function IsCreateForm() {
	return (formContext.ui.getFormType() == FORM_TYPE_CREATE && formContext.data.entity.getEntityReference().id == "") ? true : false;
}

//Base Date 설정
function setBaseDate(dateField) {
	var salesdate = formContext.getAttribute(dateField).getValue();
	var today = new Date().format('yyyy-MM-dd');
	var basedate = null;

	//alert(today);

	if (salesdate != null) {
		if (today > salesdate.format('yyyy-MM-dd')) //오늘날짜가 더 크면, Base Date = Sales Date
			basedate = salesdate.format('yyyy-MM-dd');

		else if (today <= salesdate.format('yyyy-MM-dd')) //Sales Date 더 크거나 같으면, Base Date = null
			basedate = null;
	}
	return basedate;
}

/**
 * Converts a date to an ISO 8601 string.
 * 
 * @param {string} date - The date to convert.
 * @param {Object} obj - An object with optional parameters.
 * @param {boolean} [obj.isDateOnly=true] - Whether to include only the date.
 * @param {string} [obj.hms=null] - The time to include when isDateOnly is false. Example: "09:00:00".
 * @param {boolean} [obj.isShowUTCTimeZone=null] - Whether to show the UTC timezone. Example: "+09:00".
 * @param {string} [obj.format='yyyy-MM-dd'] - The format of the date string. Used if the date parameter is a string for conversion to a date. Example: 'dd/MM/yyyy'.
 *
 * @returns {string} The date converted to an ISO 8601 string.
 *
 * @example
 * // returns '2021-12-13T09:00:00+09:00'
 * DateToStringISO8601('2021-12-13', {isDateOnly:false, hms: 'HH:mm:ss', isShowUTCTimeZone : true});
 *
 * @example
 * // returns '2021-12-13'
 * DateToStringISO8601('13/12/2021', {format: 'dd/MM/yyyy'});
 *
 * @example
 * // returns '2021-12-17T20:59:59+09:00'
 * DateToStringISO8601('17/12/2021 20:59:59', {format: 'dd/MM/yyyy HH:mm:ss', isDateOnly:false, hms:'HH:mm:ss', isShowUTCTimeZone:true});
 */
function DateToStringISO8601(date, obj) {
	var dateString = "";

	if (!date) {
		return "";
	}
	if (!obj) {

		//set default
		obj = {
			isDateOnly: true,
			hms: '',
			isShowUTCTimeZone: false,
			format: 'yyyy-MM-dd'
		};
	}
	else {
		obj.isDateOnly = obj.isDateOnly == undefined || obj.isDateOnly == null ? true : obj.isDateOnly;
		obj.hms = obj.hms || '';
		obj.isShowUTCTimeZone = obj.isShowUTCTimeZone == undefined || obj.isShowUTCTimeZone == null ? false : obj.isShowUTCTimeZone;
		obj.format = obj.format || 'yyyy-MM-dd';
	}

	if (Object.prototype.toString.call(date) !== "[object Date]") {
		var normalized = date.replace(/[^a-zA-Z0-9]/g, '-');
		var normalizedFormat = obj.format.replace(/[^a-zA-Z0-9]/g, '-');
		var formatItems = normalizedFormat.split('-');
		var dateItems = normalized.split('-');

		var monthIndex = formatItems.findIndex(x => x == 'MM' || x == 'M');
		var dayIndex = formatItems.findIndex(x => x.toLowerCase() == 'dd' || x.toLowerCase() == 'd');
		var yearIndex = formatItems.indexOf("yyyy");
		var hourIndex = formatItems.findIndex(x => x.toLowerCase() == 'hh');
		var minutesIndex = formatItems.indexOf("mm");
		var secondsIndex = formatItems.indexOf("ss");

		var today = new Date();

		// if don't have any of year, month, day, return Today
		if (yearIndex > -1 && monthIndex > -1 && dayIndex > -1) {
			var year = yearIndex > -1 ? dateItems[yearIndex] : today.getFullYear();
			var month = monthIndex > -1 ? dateItems[monthIndex] - 1 : today.getMonth() - 1;
			var day = dayIndex > -1 ? dateItems[dayIndex] : today.getDate();

			//if hourIndex not find(-1) is make all null;
			var hour = hourIndex > -1 ? dateItems[hourIndex] : null;//today.getHours();
			var minute = minutesIndex > -1 ? dateItems[minutesIndex] : null;// today.getMinutes();
			var second = secondsIndex > -1 ? dateItems[secondsIndex] : null;// today.getSeconds();

			date = new Date(year, month, day, hour, minute, second);
		}
		else {
			date = today;
		}

		//if Date is NaN, set Today
		if (isNaN(date)) {
			date = new Date();
		}
	}

	dateString = date.getFullYear() + "-" + ("0" + (date.getMonth() + 1)).slice(-2) + "-" + ("0" + date.getDate()).slice(-2);
	if (obj.isDateOnly != null && obj.isDateOnly === false) {
		if (obj.hms == null || obj.hms === "") {
			dateString += "T" + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2);// + "." + ("00" + date.getMilliseconds()).slice(-3);
		}
		else {
			var arr = obj.hms.split(':');
			if (arr.length !== 3) {
				dateString += "T" + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2); // + "." + ("00" + date.getMilliseconds()).slice(-3);
			}
			else {
				if ((parseInt(arr[0]) <= 24 && parseInt(arr[0]) >= 0) && (parseInt(arr[1]) <= 60 && parseInt(arr[1]) >= 0) && (parseInt(arr[2]) <= 60 && parseInt(arr[2]) >= 0)) {
					dateString += "T" + ("0" + arr[0]).slice(-2) + ":" + ("0" + arr[1]).slice(-2) + ":" + ("0" + arr[2]).slice(-2);
				}
				else { //IF hms set wrong, set date's hms
					dateString += "T" + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2); // + "." + ("00" + date.getMilliseconds()).slice(-3);
				}
			}
		}
	}
	if (obj.isShowUTCTimeZone != null && obj.isShowUTCTimeZone === true) {
		var offset = date.getTimezoneOffset();
		var hour = parseInt(offset / 60);
		var min = parseInt(offset % 60);
		if (hour > 0 || min > 0) { //+ means UTC -
			dateString += "-" + ("0" + hour).slice(-2) + ":" + ("0" + min).slice(-2);
		}
		else if (hour < 0 || min < 0) { // - means UTC +
			dateString += "+" + ("0" + (hour * -1)).slice(-2) + ":" + ("0" + (min * -1)).slice(-2);
		}
		else if (hour === 0 || min === 0) {
			dateString += "Z"; //Z mean '+00:00'
		}
	}
	return dateString;
}

/// <summary>
// Apply the StyleSheet given css code
/// </summary>
function AddStyleSheets(code) {
	var style = document.createElement('style');

	style.setAttribute("type", "text/css");

	if (code == "" || code == null) { //default

		// How to use : add calss into input button -> button white (bigrounded or medium or small)
		code = ".custom-button { display: inline-block; zoom: 1; /* zoom and *display = ie7 hack for display:inline-block */ *display: inline; vertical-align: baseline; margin: 0 2px; outline: none; cursor: pointer; text-align: center; text-decoration: none; font: 14px/100% Arial, Helvetica, sans-serif; padding: .5em 2em .55em; text-shadow: 0 1px 1px rgba(0,0,0,.3); -webkit-border-radius: .5em;  -moz-border-radius: .5em; border-radius: .5em; -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2); -moz-box-shadow: 0 1px 2px rgba(0,0,0,.2); box-shadow: 0 1px 2px rgba(0,0,0,.2); }"
			+ " .custom-button:hover { text-decoration: none; } .button:active { position: relative; top: 1px; }"
			+ " .custom-bigrounded { -webkit-border-radius: 2em; -moz-border-radius: 2em; border-radius: 2em; } .custom-medium { font-size: 12px; padding: .4em 1.5em .42em; } .custom-small { font-size: 11px; padding: .2em 1em .275em; }"
			+ " /* white */"
			+ " .custom-white { color: #606060; border: solid 1px #b7b7b7; background: #fff; background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ededed)); background: -moz-linear-gradient(top,  #fff,  #ededed); filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#ededed'); }"
			+ " .custom-white:hover { background: #ededed; background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#dcdcdc)); background: -moz-linear-gradient(top,  #fff,  #dcdcdc); filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#dcdcdc'); }"
			+ " .custom-white:active { color: #999; background: -webkit-gradient(linear, left top, left bottom, from(#ededed), to(#fff)); background: -moz-linear-gradient(top,  #ededed,  #fff); filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ededed', endColorstr='#ffffff'); }";
	}

	//note that it's important for IE that you append the style to the head *before* setting its content. Otherwise IE678 will *crash* is the css string contains an @import.
	var head = document.getElementsByTagName('head')[0];
	head.appendChild(style);

	if (style.styleSheet) {   // IE
		style.styleSheet.cssText = code;
	} else {                // the world
		var text = document.createTextNode(code);
		style.appendChild(text);
	}
}

// onLoad
function HideShowSection(tabName, sectionName, visible) {
	try {
		if (tabName == undefined || tabName === null) {
			throw "[HideShowSection] A parameter 'tabName' not Provided";
		}
		if (sectionName == undefined || sectionName == null) {
			throw "[HideShowSection] A parameter 'sectionName' not Provided";
		}
		if (visible == undefined || visible == null) {
			throw "[HideShowSection] A parameter 'visible'  not Provided";
		}

		var tab = formContext.ui.tabs.get(tabName);
		if (tab == undefined || tab == null) {
			throw "[HideShowSection] '" + tabName + "' Tab Not Found";
		}
		var section = tab.sections.get(sectionName);
		if (section == undefined || section == null) {
			throw "[HideShowSection] '" + sectionName + "' Section Not Found";
		}
		section.setVisible(visible);
	}
	catch (err) {
		console.log(err);

		//alert("An error occured while executing script");
	}
}

// var guid = formContext.data.entity.getEntityReference().id;
// guid = guid.replace("{", "").replace("}", "").toString();
// var cases = {
// entityType: "incident",
// id: guid
// };
// var params = {};
// OpenQuickCreateForm('new_caseaction', params, cases, function () { formContext.getControl("Case_action").refresh(); },
// function (error) { alert(error); });
function OpenQuickCreateForm(entityName, parameters, createFromEntity, successCallback, errorCallback) {
	var entityFormOptions = {};
	entityFormOptions["entityName"] = entityName;
	entityFormOptions["useQuickCreateForm"] = true;
	entityFormOptions["createFromEntity"] = createFromEntity;
	Xrm.Navigation.openForm(entityFormOptions, parameters).then(
		successCallback,
		errorCallback
	);
}

// var params = {};
// OpenNewWindowForm('new_productionrequest', params, 800, 600, formContext.data.entity.getEntityReference().id, GetCurrentFormId(), function () { }, function (error) { });
// if entityId is null, open new create form.
function OpenNewWindowForm(entityName, parameters, width, height, entityId, formId, successCallback, errorCallback) {

	//if (openNewWindow == undefined || openNewWindow === null) openNewWindow = false;

	//normal
	var entityFormOptions = {};
	entityFormOptions["entityName"] = entityName;
	entityFormOptions["useQuickCreateForm"] = false;
	entityFormOptions["openInNewWindow"] = true;
	entityFormOptions["entityId"] = entityId;
	entityFormOptions["formId"] = formId;
	entityFormOptions["width"] = width;
	entityFormOptions["height"] = height;

	Xrm.Navigation.openForm(entityFormOptions, parameters).then(
		successCallback,
		errorCallback
	);
}

/// size =   {wdith:number, height : number}
function OpenAlertDialog(text, size, title, successCalback, errorCallback) {
	if (title == undefined || title == null) {
		title = "";
	}
	var alertStrings = { confirmButtonLabel: "OK", text: text, title: title };
	if (size == undefined || size == null) {

		//size = { height: 250, width: 500 };
		size = null;
	}

	Xrm.Navigation.openAlertDialog(alertStrings, size).then(successCalback, errorCallback);
}

// var guid = formContext.data.entity.getEntityReference().id;
// guid = guid.replace("{", "").replace("}", "").toString();
// var entityReference = {
// entityType: "new_teamschedule",
// id: guid
// };
//
// var params = {};
// OpenNewWindowCopyForm('new_teamschedule', params, entityReference, 950, 600, GetCurrentFormId(), function () { }, function (error) { });
function OpenNewWindowCopyForm(entityName, parameters, createFromEntity, width, height, formId, successCallback, errorCallback) {

	//if (openNewWindow == undefined || openNewWindow === null) openNewWindow = false;

	//normal
	var entityFormOptions = {};
	entityFormOptions["entityName"] = entityName;
	entityFormOptions["useQuickCreateForm"] = false;
	entityFormOptions["openInNewWindow"] = true;
	entityFormOptions["createFromEntity"] = createFromEntity;
	entityFormOptions["formId"] = formId;
	entityFormOptions["width"] = width;
	entityFormOptions["height"] = height;

	Xrm.Navigation.openForm(entityFormOptions, parameters).then(
		successCallback,
		errorCallback
	);
}

function GetCurrentFormId() {
	var formItem = formContext.ui.formSelector.getCurrentItem();

	return (formItem != null ? formItem.getId() : null);
}

// only for  IFRAME or web resource.
// ex)  GetContentWindow('WebResource_btnEndUser',
// function(contentWindow) {
// contentWindow.document.getElementById('btnEndUser').value = "Currency Apply";
// contentWindow.document.getElementById('btnEndUser').style.color = "#111";
// });
function GetContentWindow(FieldId, successCallback, errorCallBack) {
	if (FieldId == undefined || FieldId == "") {
		if (typeof errorCallBack === "function") {
			errorCallBack("Not provide FieldId");
		}
		return;
	}
	if (typeof successCallback !== "function") {
		if (typeof errorCallBack === "function") {
			errorCallBack("Not provide successCallback as function");
		}
		return;
	}
	if (formContext.getControl(FieldId) == undefined ||
		formContext.getControl(FieldId) === null) {
		if (typeof errorCallBack === "function") {
			errorCallBack("Cannot Find the Field");
		}
		return;
	}

	if (formContext.getControl(FieldId).getObject() != undefined &&
		formContext.getControl(FieldId).getObject() !== null) {

		//check before load
		if (formContext.getControl(FieldId).getObject().src.indexOf("/_static/blank.htm") !== -1) {
			formContext.getControl(FieldId).getObject().onload = function () {
				var contentWIndow = formContext.getControl(FieldId).getObject().contentWindow;
				successCallback(contentWIndow);
			};
		} else {

			//its not work onload script(it get document beofre loaded
			successCallback(formContext.getControl(FieldId).getObject().contentWindow);
		}
	} else {
		formContext.getControl(FieldId).getContentWindow().then(function (contentWindow) {
			successCallback(contentWindow);
		}, function (error) {
			if (typeof errorCallBack === "function") {
				errorCallBack(error);
			}
		});
	}
}

//data structure
//{ "new_d_bounitusd": { element: null }, ... }
//new Array({ "new_d_bounitusd": { element: null }, ... }{ "new_d_bounitusd": { element: null }, ... })
//need attribute : element, eventType, listener, optional; onCreation
//optional attribute : opt1 (options, useCapture parameters in addEventListener)
function StartMutationObserver(data) {
	if (data == undefined || data == null) {
		console.log("StartMutationObserver : 'data' parameter not provided.");
		return;
	}
	else if (typeof data != "object") {
		console.log("StartMutationObserver : 'data' parameter is not object.");
		return;
	}

	function GetFieldElement(fieldId, isGetLastestControl) {
		var field = window.top.document.getElementById(formContext.getControl(fieldId).controlDescriptor.DomId);
		if (!field) {
			console.log("[new_js_common] GetFieldElement : cannot find field element.");
			return null;
		}

		if (isGetLastestControl == undefined || typeof isGetLastestControl !== "boolean") {
			return field;
		}

		var fieldType = formContext.getAttribute(fieldId).getAttributeType();
		if (!fieldType) {
			console.log("[new_js_common] GetFieldElement : cannot get attribute type.");
			return null;
		}

		var elements = null;
		var typeToQuery = {
			'lookup': 'input',
			'memo': 'textarea',
			'datetime': 'input',
			'decimal': 'input',
			'optionset': 'select',
			'string': 'input',
			'boolean': 'input, textarea, select'
		};

		elements = field.querySelectorAll(typeToQuery[fieldType.toLowerCase()] || 'input, textarea, select');

		if (elements.length > 0) {
			return elements[0];
		} else {
			console.log("[new_js_common] GetFieldElement : not searched by querySelector");
			return null;
		}
	}

	var key = null;
	var stopObserveCnt = 0;
	if (!Array.isArray(data)) {
		data = new Array(data);
	}
	for (var n = 0; n < data.length; n++) {
		for (key in data[n]) {
			if (data[n].hasOwnProperty(key)) stopObserveCnt += 1;
		}
	}
	// target node to be observed
	//backgroundcontainer로드 되기전에 script가 로드되는 경우가 있어 사용 불가
	//var target = parent.document.querySelector('[id^="backgroundContainer-"]'); //.getElementById('backgroundContainer-0')//parent.document.querySelector('body');

	var target = parent.document.querySelector('#mainContent');
	if (target == undefined || target == null) {
		console.error("[new_js_common] StartMutationObserver : cannot find target.");
		return;
	}

	// mutation observer config object with the listeners configuration
	var config = {

		//attributes: true,
		childList: true,
		subtree: true
	};

	// mutation observer instantiation
	const observer = new MutationObserver(function (mutations) {
		for (var i = 0; i < mutations.length; i++) {
			var mutation = mutations[i];

			//성능 저하 예상
			//if (mutation.type === 'attributes' && mutation.attributeName === 'data-lp-id') {
			//    var target = mutation.target;
			//    var a = target.getAttribute('data-lp-id').split('|');
			//    if ((endUserArr).EndsWithToArray(a[1], '.fieldControl')) {
			//        target.addEventListener('focusin', (event) => {
			//            event.target.style.border = '2px solid Red';
			//            GetContentWindow('WebResource_btnEndUser',
			//                function (contentWindow) {
			//                    contentWindow.document.getElementById('btnEndUser').value = "Currency Apply";
			//                    contentWindow.document.getElementById('btnEndUser').style.color = "#111";
			//                });
			//        });
			//    }
			//}
			if (mutation.type === 'childList') {
				for (var j = 0; j < mutation.addedNodes.length; j++) {
					var addedNode = mutation.addedNodes[j];

					//check created node
					for (var k = 0; k < data.length; k++) {
						var childData = data[k];
						if (typeof addedNode.getAttribute != "undefined" && addedNode.getAttribute("data-lp-id") != null && addedNode.getAttribute("data-lp-id").split("|").length > 1) {

							var match = JSON.StartsWithToKeys(childData, addedNode.getAttribute("data-lp-id").split("|")[1], { NextStr: ".fieldControl" });
							//id-f8a739b9-5b01-4b53-b26e-30e802aaca34-93-new_d_hqtotalkrw6
							if (match.isMatch) {
								stopObserveCnt -= 1;

								if (childData[match.MatchedString] == undefined ||
									childData[match.MatchedString] === "") {
									continue;
								}
								//need check other types field
								childData[match.MatchedString].element = GetFieldElement(match.MatchedString, true);//addedNode.childNodes[0];
								if (childData[match.MatchedString].element != null
									&& childData[match.MatchedString].eventType != undefined && childData[match.MatchedString].eventType != ''
									&& childData[match.MatchedString].listener != undefined && typeof childData[match.MatchedString].listener == 'function') {
									try {
										childData[match.MatchedString].element.addEventListener(childData[match.MatchedString].eventType, childData[match.MatchedString].listener);
									} catch (e) {
										console.error("[new_js_common] StartMutationObserver : Error occured while addEventListener")
											(console.error || console.log).call(console, e.stack || e);
									}
								}

								if (childData[match.MatchedString].onCreation != undefined && typeof childData[match.MatchedString].onCreation == 'function') {
									try {
										childData[match.MatchedString].onCreation(childData[match.MatchedString].element);
									} catch (e) {
										console.error("[new_js_common] StartMutationObserver : Error occured while executing onCreation")
											(console.error || console.log).call(console, e.stack || e);
									}
								}
							}
							else {
								var matchQuickView = JSON.StartsWithToKeys(childData, addedNode.getAttribute("data-lp-id").split("|")[1]);
								if (matchQuickView.isMatch && matchQuickView.MatchedString.indexOf('.') > -1) {
									stopObserveCnt -= 1;

									//QuickView - temporary. have to modify JSON.StartsWithToKeys
									if (childData[matchQuickView.MatchedString] == undefined ||
										childData[matchQuickView.MatchedString] === "") {
										continue;
									}

									childData[match.MatchedString].element = addedNode;
									if (childData[matchQuickView.MatchedString].onCreation != undefined && typeof childData[matchQuickView.MatchedString].onCreation == 'function') {
										try {
											childData[matchQuickView.MatchedString].onCreation(childData[matchQuickView.MatchedString].element);
										} catch (e) {
											console.error("[new_js_common] StartMutationObserver : Error occured while executing onCreation")
												(console.error || console.log).call(console, e.stack || e);
										}
									}
								}
							}
							//'MscrmControls.Containers.FieldSectionItem|new_cur_purchase_price|new_opportunity_item'
							//'MscrmControls.Containers.QuickForm|qv_opportunity|new_opportunity_item|61e151b3-1ee2-4d54-bfa2-1abf8230d787'
							//'MscrmControls.Containers.FieldSectionItem|qv_opportunity.new_l_customer|new_opportunity_item'
						}

						//모든 필요한 필드 로드가 끝나면 감시 종료 -> 지속적인 숨김처리되거나 표시 처리되면 이 부분 주석해야 계속 적용됨
						if (stopObserveCnt <= 0) {
							observer.disconnect();
						}
					}
				}
			}
		}
	});

	// observe initialization
	observer.observe(target, config);
}

Array.prototype.ContainsToArray = function (str, attachNextStr) {
	if (str == undefined || str === null || typeof str !== "string" || str === "") {
		return false;
	}
	for (var i = 0; i < this.length; i++) {
		if (str.indexOf(this[i] + (attachNextStr != null ? attachNextStr : "")) !== -1) {
			return true;
		}
	}
	return false;
};

Array.prototype.StartsWithToArray = function (str, attachNextStr) {
	if (str == undefined || str === null || typeof str !== "string" || str === "") {
		return false;
	}
	for (var i = 0; i < this.length; i++) {
		if (str.startsWith(this[i] + (attachNextStr != null ? attachNextStr : ""))) {
			return true;
		}
	}
	return false;
};

Array.prototype.EndsWithToArrayMatch = function (str, attachNextStr) {
	if (str == undefined || str === null || typeof str !== "string" || str === "") {
		return false;
	}
	for (var i = 0; i < this.length; i++) {
		if (str.endsWith(this[i] + (attachNextStr != null ? attachNextStr : ""))) {
			return true;
		}
	}
	return false;
};

Array.prototype.EndsWithToArray = function (str, attachNextStr) {
	var rtn = { isMatch: false, MatchedString: null };
	if (str == undefined || str === null || typeof str !== "string" || str === "") {
		return rtn;
	}
	for (var i = 0; i < this.length; i++) {
		if (str.endsWith(this[i] + (attachNextStr != null ? attachNextStr : ""))) {
			rtn.isMatch = true;
			rtn.MatchedString = this[i];
		}
	}
	return rtn;
};

/**
 * Set default options if not provided.
 * @param {Object} opt - The options object. It can have the following properties:
 *                        - PrevStr: The string to be added before the key.
 *                        - NextStr: The string to be added after the key.
 * @returns {Object} The options object with default values.
 */
function setOptions(opt) {
	var options = opt || {};
	options.PrevStr = options.PrevStr || "";
	options.NextStr = options.NextStr || "";
	return options;
}

/**
 * Check keys in the object based on the check function.
 * @param {Object} obj - The object to check keys.
 * @param {string} str - The string to check with.
 * @param {Function} checkFunc - The function to check the string with the key.
 * @param {Object} opt - The options object. It can have the following properties:
 *                        - PrevStr: The string to be added before the key.
 *                        - NextStr: The string to be added after the key.
 * @returns {Object} The result object with isMatch and MatchedString properties.
 */
function checkKeys(obj, str, checkFunc, opt) {
	var rtn = { isMatch: false, MatchedString: null };
	if (!str || typeof str !== "string") return rtn;

	opt = setOptions(opt);

	for (var key in obj) {
		if (Object.prototype.hasOwnProperty.call(obj, key)) {
			var target = opt.PrevStr + key + opt.NextStr;
			if (checkFunc(str, target)) {
				rtn.isMatch = true;
				rtn.MatchedString = key;
				break;
			}
		}
	}
	return rtn;
}

/**
 * Check if the string starts with any of the keys in the object.
 * @param {Object} obj - The object to check keys.
 * @param {string} str - The string to check with.
 * @param {Object} opt - The options object. It can have the following properties:
 *                        - PrevStr: The string to be added before the key.
 *                        - NextStr: The string to be added after the key.
 * @returns {Object} The result object with isMatch and MatchedString properties.
 */
JSON.StartsWithToKeys = function (obj, str, opt) {
	return checkKeys(obj, str, function (s, t) { return s.startsWith(t); }, opt);
};

/**
 * Check if the string contains any of the keys in the object.
 * @param {Object} obj - The object to check keys.
 * @param {string} str - The string to check with.
 * @param {Object} opt - The options object. It can have the following properties:
 *                        - PrevStr: The string to be added before the key.
 *                        - NextStr: The string to be added after the key.
 * @returns {Object} The result object with isMatch and MatchedString properties.
 */
JSON.ContainsToKeys = function (obj, str, opt) {
	return checkKeys(obj, str, function (s, t) { return s.indexOf(t) !== -1; }, opt);
};

/**
 * Check if the string is equal to any of the keys in the object.
 * @param {Object} obj - The object to check keys.
 * @param {string} str - The string to check with.
 * @param {Object} opt - The options object. It can have the following properties:
 *                        - PrevStr: The string to be added before the key.
 *                        - NextStr: The string to be added after the key.
 * @returns {Object} The result object with isMatch and MatchedString properties.
 */
JSON.EqualToKeys = function (obj, str, opt) {
	return checkKeys(obj, str, function (s, t) { return s === t; }, opt);
};