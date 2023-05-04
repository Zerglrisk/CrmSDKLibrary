﻿var $ = parent.$;
var _formContext;
var globalContext = (window.Xrm != undefined ? Xrm.Utility.getGlobalContext() : null);
var FORM_TYPE_CREATE = 1;
var FORM_TYPE_UPDATE = 2;
var FORM_TYPE_READONLY = 3;
var mutationObs = null;

Object.defineProperty(this, 'formContext', {
    get: function () { return _formContext; },
    set: function (v) {
        _formContext = v;

        // overwrite formcontext properties
        //_formContext.context.getQueryStringParameters = function () {
        //    var params = {};
        //    window.top.location.search.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (str, key, value) { params[key] = value; });
        //    return params;
        //}

        // add lines for formcontext properties;
        if (_formContext.trueinfo == undefined) {
            _formContext.trueinfo = {};
        }
        if (_formContext.trueinfo.debug == undefined) {
            _formContext.trueinfo.debug = {};
        }
        if (_formContext.trueinfo.WebApi == undefined) {
            _formContext.trueinfo.WebApi = {};
        }

        try {
            _formContext.trueinfo.debug.openByGuid = function (entityName, entityId, width, height) {

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
                var entityFormOptions = {};
                entityFormOptions["entityName"] = entityName;
                entityFormOptions["useQuickCreateForm"] = false;
                entityFormOptions["openInNewWindow"] = true;
                entityFormOptions["entityId"] = entityId;
                entityFormOptions["formId"] = (formItem != null ? formItem.getId() : null);
                entityFormOptions["width"] = (width != null ? width : 950);
                entityFormOptions["height"] = (height != null ? height : 600);

                Xrm.Navigation.openForm(entityFormOptions, parameters).then(
                    function (e) {
                        console.log(e);
                    },
                    function (error) {
                        console.log(error);
                    }
                );
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.debug.openByGuid.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.debug.openCopyForm = function (entityName, entityId, width, height) {
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
                    entityName = prompt("Enter the records entity internalname (ex; account, new_contact)", formContext.data.entity.getEntityName());
                }
                //var etcetn = Number.isInteger(entity) ? "?etc=" : "?etn=";
                if (entityId == null) {
                    entityId = prompt("Enter the records GUID", guid);
                }

                var formItem = formContext.ui.formSelector.getCurrentItem();
                var parameters = {};
                //normal
                var entityFormOptions = {};
                entityFormOptions["entityName"] = entityName;
                entityFormOptions["useQuickCreateForm"] = false;
                entityFormOptions["openInNewWindow"] = true;
                entityFormOptions["createFromEntity"] = { entityType: entityName, id: entityId };
                entityFormOptions["formId"] = (formItem != null ? formItem.getId() : null);
                entityFormOptions["width"] = (width != null ? width : 950);
                entityFormOptions["height"] = (height != null ? height : 600);

                Xrm.Navigation.openForm(entityFormOptions, parameters).then(
                    function (e) {
                        console.log(e);
                    },
                    function (error) {
                        console.log(error);
                    }
                );
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.debug.openCopyForm.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.debug.getEntityTypeCodeSync = async function (entityName) {
                if (entityName == null) {
                    entityName = prompt("Enter the records entity internalname (ex; account, new_contact)", formContext.data.entity.getEntityName());
                }
                var objectTypeCode = null;
                //Getting entity Metadata to get otc (Object Type Code)

                await Xrm.Utility.getEntityMetadata(entityName).then(
                    function (entityMetadata) {
                        objectTypeCode = entityMetadata.ObjectTypeCode;
                    });

                return objectTypeCode;
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.debug.getEntityTypeCode.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.OpenWebResourceDialog = function (data, width, height, isSide, webresourceName) {
                if (data == null) {
                    console.log("[new_u_js_common] OpenWebResourceDialog : not provide data parameter.(required)");
                    return;
                }
                if (width == null) {
                    width = { value: 50, unit: "%" };
                }
                if (height == null) {
                    height == null;
                }
                var position = 1;
                if (isSide != null && isSide === true) {
                    position = 2;
                }
                if (webresourceName == null || webresourceName == "") {
                    webresourceName = "new_u_html_dialog_template";
                }
                Xrm.Navigation.navigateTo({ pageType: "webresource", webresourceName: webresourceName, data: data }, { target: 2, position: position, width: width, height: height });
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.OpenWebResourceDialog.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.WebApi.GetEntityMetadata = function (entityLogicalName, successCallback, errorCallback) {
                if (entityLogicalName == undefined || entityLogicalName === "") {
                    entityLogicalName = formContext.data.entity.getEntityName();
                }
                //Getting entity Metadata to get otc (Object Type Code)
                Xrm.Utility.getEntityMetadata(entityLogicalName).then(successCallback, errorCallback);
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.GetEntityTypeCode.");
            console.error(ex);
        }
        try {
            _formContext.trueinfo.WebApi.SetStatus = function (statecode, statuscode, successCallBack, errorCallBack) {
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
                    }
                }

                // WebApi call
                Xrm.WebApi.updateRecord(entityLogicalName, id, data).then(successCallBack, errorCallBack);
            };
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.SetStatus.");
            console.error(ex);
        }
        try {
            _formContext.trueinfo.WebApi.Update = function (data, successCallBack, errorCallBack) {
                var entityLogicalName = _formContext.data.entity.getEntityName();
                // Remove brackets from the GUID if there’s any
                var id = _formContext.data.entity.getEntityReference().id.replace("{", "").replace("}", "").toString();

                // WebApi call
                Xrm.WebApi.updateRecord(entityLogicalName, id, data).then(successCallBack, errorCallBack);
            };
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.SetStatus.");
            console.error(ex);
        }

        try {
            //only for subgrid in uci ( not work even set on form editor )
            // Deprecated, Rederning Order Changed. (if want fix it, use mutationobserver that you can spying grid render time.)
            _formContext.trueinfo.SetSubGridHeaderColor = function (subGridId) {
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
                        console.error("[new_u_js_common] SetSubGridHeaderColor : Cannot find EventSource");
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
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.SetSubGridHeaderColor.");
            console.error(ex);
        }
        try {

            //only for UCI
            //field tag generate 되기 전에 미리 dom ID를 알 수 있다. mutation observer를 사용하여 필드가 load 되었는지 감시할 때 사용 가능
            _formContext.trueinfo.getDomId = function (fieldId) {
                if (fieldId == null || fieldId == "") {
                    return null;
                }
                return _formContext.getControl(fieldId).controlDescriptor.DomId;
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.getDomId.");
            console.error(ex);
        }
        try {
            _formContext.trueinfo.getCurrentFormId = function () {
                var formItem = formContext.ui.formSelector.getCurrentItem();
                return (formItem != null ? formItem.getId() : null);
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.getDomId.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.WebApi.ReplaceImageBlobToCrmAPI = function (fieldid) {
                if (!_formContext.getAttribute(fieldid)) {
                    console.error("[new_u_js_common] UpdateImageBlob : cannot find '" + fieldid + "' field.");
                    return null;
                }
                //괄호 포함 /\((.*?)\)/g
                //괄호 미포함 /(?<=\().+?(?=\))/g
                var template = document.createElement("div");
                var replaceStr = _formContext.getAttribute(fieldid).getValue()
                template.innerHTML = replaceStr.trim();
                var imgs = template.getElementsByTagName("img");

                for (var i = 0; i < imgs.length; ++i) {
                    if (imgs[i].src.indexOf('msdyn_richtextfiles') == -1) {
                        continue;
                    }

                    var regx = /\((.*?)\)/g
                    var m = regx.exec(imgs[i].src);
                    var targetId = m[0].replace("(", "").replace(")", "");
                    console.log(targetId);

                    //수정필요 src부분의 XXX/api XXX부분 삭제(http:///불라불라 호스트)
                    replaceStr = replaceStr.replace(imgs[i].src.replace(window.top.window.location.origin, ''), "https://crmweb.kohyoung.net:447/Services/ContentService.svc/imageblob/" + targetId);
                }
                //target
                console.log(replaceStr);
                return replaceStr;
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.getDomId.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.WebApi.RetrieveGlobalOptionSets = function (optionsetName) {
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
            }

        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.RetrieveGlobalOptionSets.");
            console.error(ex);
        }

        try {
            // usage : RetrieveGlobalOptionSetsAsync('new_p_calltype2').then(function (a){ console.log(a);}).catch(function(err){ console.log(err);});
            _formContext.trueinfo.WebApi.RetrieveGlobalOptionSetsAsync = function (optionsetName) {
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
                            })

                            console.log(error.message);
                        }
                    };
                    req.onerror = function () {
                        reject({
                            status: this.status,
                            statusText: req.statusText
                        });
                    }
                    req.send();
                });
            }

        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.RetrieveGlobalOptionSetsAsync.");
            console.error(ex);
        }

        try {
            //Query Must startwith '?'
            // Using RetrieveEntityManyToManyRelationshipRecordsAsync('teams','10b9fbe0-fa54-e911-a988-000d3aa37980','teammembership_association','');
            // Using RetrieveEntityManyToManyRelationshipRecordsAsync('systemusers','dae9b66d-4610-ec11-b6e6-000d3a82ed38','new_new_salesoffice_systemuser','?$select=new_name&$filter=new_chk_useincalendar eq true&$orderby=new_i_order');
            // Using RetrieveEntityManyToManyRelationshipRecordsAsync('new_salesoffices','2b8ccdde-fe1f-ec11-b6e6-000d3a852496','new_new_salesoffice_systemuser','?$select=fullname&$filter=isdisabled eq false and accessmode eq 0 and trueinfo_fc_inc_tc eq true and new_chk_anzuser eq true&$orderby=fullname asc');
            _formContext.trueinfo.WebApi.RetrieveEntityManyToManyRelationshipRecordsAsync = function (entitySetName, entityRecordId, relationshipSchemaName, query) {
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
                            })

                            console.log(error.message);
                        }
                    };
                    req.onerror = function () {
                        reject({
                            status: this.status,
                            statusText: req.statusText
                        });
                    }
                    req.send();
                });
            }

        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.RetrieveEntityManyToManyRelationshipRecordsAsync.");
            console.error(ex);
        }
        try {
            _formContext.trueinfo.WebApi.RetrieveAttributeMetadataAsync = function (entityLogicalName, attributeName) {
                return new Promise(function (resolve, reject) {
                    var req = new XMLHttpRequest();
                    req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/EntityDefinitions(LogicalName='${entityLogicalName}')/Attributes(LogicalName='${attributeName}')`)
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Prefer", "odata.include-annotations=*");
                    req.onload = function () {
                        if (this.status >= 200 && this.status < 300) {
                            var jobj = JSON.parse(req.response);
                            if (jobj && jobj["@odata.type"]) {
                                RetrieveAttributeMetadataDetailAsync(entityLogicalName, attributeName, jobj["@odata.type"]).then(function (results) {
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
                            }
                            else {
                                resolve(JSON.parse(req.response));
                            }
                        } else {
                            var error = JSON.parse(req.response).error;
                            reject({
                                status: this.status,
                                statusText: error.message,
                            })

                            console.log(error.message);
                        }
                    };
                    req.onerror = function () {
                        reject({
                            status: this.status,
                            statusText: req.statusText
                        });
                    }
                    req.send();
                });
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.RetrieveAttributeMetadataAsync.");
            console.error(ex);
        }
        try {
            _formContext.trueinfo.WebApi.RetrieveAttributeMetadataDetailAsync = function (entityLogicalName, attributeName, odataType) {
                return new Promise(function (resolve, reject) {
                    var odataTpyeQuery = '';
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
                    }
                    else if (odataType == '#Microsoft.Dynamics.CRM.BooleanAttributeMetadata') {
                        expand = '?$expand=GlobalOptionSet($select=FalseOption,TrueOption)';
                        //GlobalOptionSet Only
                    }
                    else {
                        expand = '';
                    }
                    odataTpyeQuery = `/${odataType.replace('#', '')}${expand}`;
                    var req = new XMLHttpRequest();
                    req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/EntityDefinitions(LogicalName='${entityLogicalName}')/Attributes(LogicalName='${attributeName}')${odataTpyeQuery}`)
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
                            })

                            console.log(error.message);
                        }
                    };
                    req.onerror = function () {
                        reject({
                            status: this.status,
                            statusText: req.statusText
                        });
                    }
                    req.send();
                });
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.RetrieveAttributeMetadataDetailAsync.");
            console.error(ex);
        }

        try {
            _formContext.trueinfo.WebApi.RetrieveEntityRelationshipMetadataAsync = function (entityLogicalName, RelationshipType, SchemaName) {
                return new Promise(function (resolve, reject) {
                    if (RelationshipType !== 'OneToManyRelationships' && RelationshipType !== 'ManyToManyRelationships' && RelationshipType !== ManyToOneRelationships) {
                        reject({
                            status: 0,
                            statusText: 'Unknown RelationshipType.',
                        });
                        return;
                    }
                    if (!SchemaName) {
                        SchemaName = '';
                    }
                    else {
                        SchemaName = `(SchemaName='${SchemaName}')`;
                    }
                    var req = new XMLHttpRequest();
                    req.open('GET', Xrm.Page.context.getClientUrl() + `/api/data/v9.0/EntityDefinitions(LogicalName='${entityLogicalName}')/${RelationshipType}${SchemaName}`);
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Prefer", "odata.include-annotations=*");
                    req.onload = function () {
                        if (this.status >= 200 && this.status < 300) {
                            var jobj = JSON.parse(req.response);
                            if (jobj && jobj["@odata.type"]) {
                                RetrieveAttributeMetadataDetailAsync(entityLogicalName, attributeName, jobj["@odata.type"]).then(function (results) {
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
                            }
                            else {
                                resolve(JSON.parse(req.response));
                            }
                        } else {
                            var error = JSON.parse(req.response).error;
                            reject({
                                status: this.status,
                                statusText: error.message,
                            })

                            console.log(error.message);
                        }
                    };
                    req.onerror = function () {
                        reject({
                            status: this.status,
                            statusText: req.statusText
                        });
                    }
                    req.send();
                });
            }
        } catch (ex) {
            console.error("[new_u_js_common] Failed To Load formContext.trueinfo.WebApi.RetrieveEntityRelationshipMetadataAsync.");
            console.error(ex);
        }

        //for use formcontext easily from iframe or webresource
        window.top.formContext = _formContext;
        console.log("[new_u_js_common] Defined formContext from new_js_common to window.top");
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

//formContext Load용
function loadContext(executionContext) {
    formContext = executionContext.getFormContext();
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

    $("#panel").hide()
        .css({ 'position': 'absolute', 'top': '0', 'left': '0', 'width': '100%', 'height': '100%', 'background-color': '#FFFFFF', 'opacity': '0.5' });

    $("#contentDiv").append('<img id="loading" src="https://kohyoung.crm5.dynamics.com//WebResources/new_gif_progress" style="width:45px; height:45px;" />')
        .hide();
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
            ("#contentDiv").hide();
        });
    });
    $("#panel").remove();
    $("#contentDiv").remove();
}

//URL 파라미터 조회
function getURLParameter(name) {
    return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || ""
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

///<summary>
/// isDateOnly default : true
/// hms defualt : null (example to using "09:00:00") this parameter using when isDateOnly is false.
/// isShowUTCTimeZone default : null (example to using UTC Timezone shows like this "+09:00" ).
///</summary>
//function DateToStringISO8601(date, isDateOnly, hms, isShowUTCTimeZone) {
//    var dateString = "";

//    if (date == null || date == "") {
//        return "";
//    }
//    if (Object.prototype.toString.call(date) !== "[object Date]") {
//        date = new Date(date);
//        //if Date is NaN, set Today
//        if (isNaN(date)) {
//            date = new Date();
//        }
//    }

//    dateString = date.getFullYear() + "-" + ("0" + (date.getMonth() + 1)).slice(-2) + "-" + ("0" + date.getDate()).slice(-2);
//    if (isDateOnly != null && isDateOnly === false) {
//        if (hms == null || hms === "") {
//            dateString += "T" + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2);// + "." + ("00" + date.getMilliseconds()).slice(-3);
//        }
//        else {
//            var arr = hms.split(':');
//            if (arr.length !== 3) {
//                dateString += "T" + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2); // + "." + ("00" + date.getMilliseconds()).slice(-3);
//            }
//            else {
//                if ((parseInt(arr[0]) <= 24 && parseInt(arr[0]) >= 0) && (parseInt(arr[1]) <= 60 && parseInt(arr[1]) >= 0) && (parseInt(arr[2]) <= 60 && parseInt(arr[2]) >= 0)) {
//                    dateString += "T" + ("0" + arr[0]).slice(-2) + ":" + ("0" + arr[1]).slice(-2) + ":" + ("0" + arr[2]).slice(-2);
//                }
//                else { //IF hms set wrong, set date's hms
//                    dateString += "T" + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2); // + "." + ("00" + date.getMilliseconds()).slice(-3);
//                }
//            }
//        }
//    }
//    if (isShowUTCTimeZone != null && isShowUTCTimeZone === true) {
//        var offset = date.getTimezoneOffset();
//        var hour = parseInt(offset / 60);
//        var min = parseInt(offset % 60);
//        if (hour > 0 || min > 0) { //+ means UTC - 
//            dateString += "-" + ("0" + hour).slice(-2) + ":" + ("0" + min).slice(-2);
//        }
//        else if (hour < 0 || min < 0) { // - means UTC +
//            dateString += "+" + ("0" + (hour * -1)).slice(-2) + ":" + ("0" + (min * -1)).slice(-2);
//        }
//        else if (hour === 0 || min === 0) {
//            dateString += "Z"; //Z mean '+00:00'
//        }
//    }
//    return dateString;
//}


///<summary>
/// isDateOnly default : true
/// hms defualt : null (example to using "09:00:00") this parameter using when isDateOnly is false.
/// isShowUTCTimeZone default : null (example to using UTC Timezone shows like this "+09:00" ).
/// format default: 'yyyy-MM-dd' (example to using 'dd/MM/yyyy') this parameter using if date parameter is string for convert to date.
///</summary>
/// Usage : DateToStringISO8601('2021-12-13', {isDateOnly:false, hms: 'HH:mm:ss', isShowUTCTimeZone : true});
/// Usage : DateToStringISO8601('13/12/2021', {format: 'dd/MM/yyyy});
/// Usage : DateToStringISO8601('17/12/2021 20:59:59', {format: 'dd/MM/yyyy HH:mm:ss', isDateOnly:false, hms:'HH:mm:ss', isShowUTCTimeZone:true});
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
function AddStyleSheets(id, code) {
    var style = document.createElement('style');
    //style.type = 'text/css';
    style.setAttribute("type", "text/css");
    //var code = '';
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
    if (id == null) {
        var head = document.getElementsByTagName('head')[0];
        head.appendChild(style);
    }
    else {
        var head = $('#' + id).context.getElementsByTagName('head')[0];
        head.appendChild(style);
    }

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

//only for UCI
function GetFieldElement(fieldId, isGetLastestControl) {

    var field = window.top.document.getElementById(formContext.getControl(fieldId).controlDescriptor.DomId);
    if (field == undefined) {
        console.log("[new_u_js_common] GetFieldElement : cannot find field element.");
        return null;
    }

    if (isGetLastestControl == undefined || typeof isGetLastestControl !== "boolean") {
        return field;
    }

    var fieldType = formContext.getAttribute(fieldId).getAttributeType();
    if (fieldType == undefined) {
        console.log("[new_u_js_common] GetFieldElement : cannot get attribute type.");
        return null;
    }
    var elements = null;
    if (fieldType.toLowerCase().indexOf('lookup') !== -1) {
        //lookup
        elements = field.querySelectorAll('input');
    } else if (fieldType.toLowerCase().indexOf('memo') !== -1) {
        //ntxt
        elements = field.querySelectorAll('textarea');
    } else if (fieldType.toLowerCase().indexOf('datetime') !== -1) {
        //datetime
        elements = field.querySelectorAll('input');
    } else if (fieldType.toLowerCase().indexOf('decimal') !== -1) {
        //decimal
        elements = field.querySelectorAll('input');
    } else if (fieldType.toLowerCase().indexOf('optionset') !== -1) {
        //optionset
        elements = field.querySelectorAll('select');
    } else if (fieldType.toLowerCase().indexOf('string') !== -1) {
        //txt
        elements = field.querySelectorAll('input');
    } else if (fieldType.toLowerCase().indexOf('boolean') !== -1) {
        //chk
        //...
        elements = field.querySelectorAll('input, textarea, select');
    } else {
        elements = field.querySelectorAll('input, textarea, select');
    }

    if (elements.length > 0) {
        return elements[0];
    } else {
        console.log("[new_u_js_common] GetFieldElement : not searched by querySelector");
        return null;
    }
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
//need attribute : element, eventType, listener
//optional attribute : opt1 (options, useCapture parameters in addEventListener)
function startMutationObserver(data) {
    if (data == undefined || data == null) {
        console.log("startMutationObserver : 'data' parameter not provided.");
        return;
    }
    var key = null;
    var stopObserveCnt = 0;
    if (typeof data == "object") {
        if (Array.isArray(data)) {
            for (var n = 0; n < data.length; n++) {
                for (key in data[n]) {
                    if (data[n].hasOwnProperty(key)) stopObserveCnt += 1;
                }
            }

            startMutationObserverCustom(function (mutations) {
                for (var i = 0; i < mutations.length; i++) {
                    var mutation = mutations[i];
                    if (mutation.type === 'childList') {
                        for (var j = 0; j < mutation.addedNodes.length; j++) {
                            var addedNode = mutation.addedNodes[j];

                            //check created node
                            for (var k = 0; k < data.length; k++) {
                                var childData = data[k];
                                if (typeof addedNode.getAttribute != "undefined" && addedNode.getAttribute("data-lp-id") != null &&
                                    addedNode.getAttribute("data-lp-id").split("|").length > 1) {
                                    var match = JSON.StartsWithToKeys(childData, addedNode.getAttribute("data-lp-id").split("|")[1], { NextStr: ".fieldControl" });
                                    //id-f8a739b9-5b01-4b53-b26e-30e802aaca34-93-new_d_hqtotalkrw6
                                    if (match.isMatch) {
                                        stopObserveCnt -= 1;

                                        if (childData[match.MatchedString] == undefined ||
                                            childData[match.MatchedString] == null ||
                                            childData[match.MatchedString] === "") {
                                            continue;
                                        }
                                        if (childData[match.MatchedString].listener == undefined ||
                                            childData[match.MatchedString].listener == null) {
                                            continue;
                                        }

                                        //need check other types field
                                        childData[match.MatchedString].element = GetFieldElement(match.MatchedString, true);//addedNode.childNodes[0];
                                        if (childData[match.MatchedString].element != null) {
                                            childData[match.MatchedString].element.addEventListener(childData[match.MatchedString].eventType,
                                                childData[match.MatchedString].listener);
                                        }
                                    }
                                }

                                //모든 필요한 필드 로드가 끝나면 감시 종료
                                if (stopObserveCnt <= 0) {
                                    stopMutationObserver();
                                }
                            }

                        }
                    }
                }
            });

        } else {
            for (key in data) {
                if (data.hasOwnProperty(key)) stopObserveCnt += 1;
            }

            startMutationObserverCustom(function (mutations) {
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
                            var match = JSON.StartsWithToKeys(data, addedNode.getAttribute("data-id"), { NextStr: '.fieldControl-' });
                            if (match.isMatch) {
                                stopObserveCnt -= 1;
                                //need check other types field
                                if (data[match.MatchedString] == undefined ||
                                    data[match.MatchedString] == null ||
                                    data[match.MatchedString] == "") {
                                    continue;
                                }
                                if (data[match.MatchedString].listener == undefined ||
                                    data[match.MatchedString].listener == null) {
                                    continue;
                                }

                                data[match.MatchedString].element = addedNode.childNodes[0];
                                addedNode.addEventListener(data[match.MatchedString].eventType,
                                    data[match.MatchedString].listener);
                            }

                            //모든 필요한 필드 로드가 끝나면 감시 종료
                            if (stopObserveCnt <= 0) {
                                stopMutationObserver();
                            }
                        }
                    }
                }
            });

        }
    }
}

function startMutationObserverCustom(callbackAttributeChange) {
    // target node to be observed
    //backgroundcontainer로드 되기전에 script가 로드되는 경우가 있어 사용 불가
    //var target = parent.document.querySelector('[id^="backgroundContainer-"]'); //.getElementById('backgroundContainer-0')//parent.document.querySelector('body');

    var target = parent.document.querySelector('#mainContent');
    if (target == undefined || target == null) {
        console.error("[new_u_js_common] startMutationObserverCustom : cannot find target.");
        return;
    }

    // mutation observer config object with the listeners configuration
    var config = {
        //attributes: true,
        childList: true,
        subtree: true
    };

    // mutation observer instantiation
    mutationObs = new MutationObserver(callbackAttributeChange);

    // observe initialization
    mutationObs.observe(target, config);
}

function stopMutationObserver() {
    mutationObs.disconnect();
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
}

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
}

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
}

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
}

//for only json object 
//ex) obj { "a":1, "b":2, ... }, 
//opt structure
// { PrevStr: '', NextStr: ''} its for attach string into obj key string
JSON.EndsWithToKeys = function (obj, str, opt) {
    var rtn = { isMatch: false, MatchedString: null };
    if (str == undefined || str === null || typeof str !== "string" || str === "") {
        return rtn;
    }

    var prevStr = "";
    var nextStr = "";
    if (opt != undefined && typeof opt == "object") {
        if (opt.hasOwnProperty("PrevStr")) {
            prevStr = opt.PrevStr;
        }
        if (opt.hasOwnProperty("NextStr")) {
            nextStr = opt.NextStr;
        }
    }

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            var target = key;
            if (str.endsWith(prevStr + target + nextStr)) {
                rtn.isMatch = true;
                rtn.MatchedString = key;
                break;
            }
        }
    }
    return rtn;
}


//opt structure
// { PrevStr: '', NextStr: ''} its for attach string into obj key string
JSON.StartsWithToKeys = function (obj, str, opt) {
    var rtn = { isMatch: false, MatchedString: null };
    if (str == undefined || str === null || typeof str !== "string" || str === "") {
        return rtn;
    }
    var prevStr = "";
    var nextStr = "";
    if (opt != undefined && typeof opt == "object") {
        if (opt.hasOwnProperty("PrevStr")) {
            prevStr = opt.PrevStr;
        }
        if (opt.hasOwnProperty("NextStr")) {
            nextStr = opt.NextStr;
        }
    }

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            var target = key;
            if (str.startsWith(prevStr + target + nextStr)) {
                rtn.isMatch = true;
                rtn.MatchedString = key;
                break;
            }
        }
    }
    return rtn;
}


//opt structure
// { PrevStr: '', NextStr: ''} its for attach string into obj key string
JSON.ContainsToKeys = function (obj, str, opt) {
    var rtn = { isMatch: false, MatchedString: null };
    if (str == undefined || str === null || typeof str !== "string" || str === "") {
        return rtn;
    }
    var prevStr = "";
    var nextStr = "";
    if (opt != undefined && typeof opt == "object") {
        if (opt.hasOwnProperty("PrevStr")) {
            prevStr = opt.PrevStr;
        }
        if (opt.hasOwnProperty("NextStr")) {
            nextStr = opt.NextStr;
        }
    }

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            var target = key;
            if (str.indexOf(prevStr + target + nextStr) !== -1) {
                rtn.isMatch = true;
                rtn.MatchedString = key;
                break;
            }
        }
    }
    return rtn;
}


//opt structure
// { PrevStr: '', NextStr: ''} its for attach string into obj key string
JSON.EqualToKeys = function (obj, str, opt) {
    var rtn = { isMatch: false, MatchedString: null };
    if (str == undefined || str === null || typeof str !== "string" || str === "") {
        return rtn;
    }
    var prevStr = "";
    var nextStr = "";
    if (opt != undefined && typeof opt == "object") {
        if (opt.hasOwnProperty("PrevStr")) {
            prevStr = opt.PrevStr;
        }
        if (opt.hasOwnProperty("NextStr")) {
            nextStr = opt.NextStr;
        }
    }

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            var target = key;
            if (str === (prevStr + target + nextStr)) {
                rtn.isMatch = true;
                rtn.MatchedString = key;
                break;
            }
        }
    }
    return rtn;
}

function deepFreeze(object) {

    // 객체에 정의된 속성명을 추출
    var propNames = Object.getOwnPropertyNames(object);

    // 스스로를 동결하기 전에 속성을 동결

    for (let name of propNames) {
        let value = object[name];

        object[name] = value && typeof value === "object" ?
            deepFreeze(value) : value;
    }

    return Object.freeze(object);
}