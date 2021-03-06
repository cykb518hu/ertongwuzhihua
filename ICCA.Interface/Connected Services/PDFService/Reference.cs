//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICCA.Interface.PDFService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseData", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class ResponseData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string errorField;
        
        private int resultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string error {
            get {
                return this.errorField;
            }
            set {
                if ((object.ReferenceEquals(this.errorField, value) != true)) {
                    this.errorField = value;
                    this.RaisePropertyChanged("error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int result {
            get {
                return this.resultField;
            }
            set {
                if ((this.resultField.Equals(value) != true)) {
                    this.resultField = value;
                    this.RaisePropertyChanged("result");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PDFService.DocumentTransferSoap")]
    public interface DocumentTransferSoap {
        
        // CODEGEN: Generating message contract since element name message from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UploadDoc", ReplyAction="*")]
        ICCA.Interface.PDFService.UploadDocResponse UploadDoc(ICCA.Interface.PDFService.UploadDocRequest request);
        
        // CODEGEN: Generating message contract since element name message from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RemoveDoc", ReplyAction="*")]
        ICCA.Interface.PDFService.RemoveDocResponse RemoveDoc(ICCA.Interface.PDFService.RemoveDocRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadDocRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UploadDoc", Namespace="http://tempuri.org/", Order=0)]
        public ICCA.Interface.PDFService.UploadDocRequestBody Body;
        
        public UploadDocRequest() {
        }
        
        public UploadDocRequest(ICCA.Interface.PDFService.UploadDocRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadDocRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string message;
        
        public UploadDocRequestBody() {
        }
        
        public UploadDocRequestBody(string message) {
            this.message = message;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadDocResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UploadDocResponse", Namespace="http://tempuri.org/", Order=0)]
        public ICCA.Interface.PDFService.UploadDocResponseBody Body;
        
        public UploadDocResponse() {
        }
        
        public UploadDocResponse(ICCA.Interface.PDFService.UploadDocResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadDocResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public ICCA.Interface.PDFService.ResponseData response;
        
        public UploadDocResponseBody() {
        }
        
        public UploadDocResponseBody(ICCA.Interface.PDFService.ResponseData response) {
            this.response = response;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RemoveDocRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RemoveDoc", Namespace="http://tempuri.org/", Order=0)]
        public ICCA.Interface.PDFService.RemoveDocRequestBody Body;
        
        public RemoveDocRequest() {
        }
        
        public RemoveDocRequest(ICCA.Interface.PDFService.RemoveDocRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class RemoveDocRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string message;
        
        public RemoveDocRequestBody() {
        }
        
        public RemoveDocRequestBody(string message) {
            this.message = message;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RemoveDocResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RemoveDocResponse", Namespace="http://tempuri.org/", Order=0)]
        public ICCA.Interface.PDFService.RemoveDocResponseBody Body;
        
        public RemoveDocResponse() {
        }
        
        public RemoveDocResponse(ICCA.Interface.PDFService.RemoveDocResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class RemoveDocResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public ICCA.Interface.PDFService.ResponseData response;
        
        public RemoveDocResponseBody() {
        }
        
        public RemoveDocResponseBody(ICCA.Interface.PDFService.ResponseData response) {
            this.response = response;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DocumentTransferSoapChannel : ICCA.Interface.PDFService.DocumentTransferSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DocumentTransferSoapClient : System.ServiceModel.ClientBase<ICCA.Interface.PDFService.DocumentTransferSoap>, ICCA.Interface.PDFService.DocumentTransferSoap {
        
        public DocumentTransferSoapClient() {
        }
        
        public DocumentTransferSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DocumentTransferSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocumentTransferSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocumentTransferSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICCA.Interface.PDFService.UploadDocResponse ICCA.Interface.PDFService.DocumentTransferSoap.UploadDoc(ICCA.Interface.PDFService.UploadDocRequest request) {
            return base.Channel.UploadDoc(request);
        }
        
        public ICCA.Interface.PDFService.ResponseData UploadDoc(string message) {
            ICCA.Interface.PDFService.UploadDocRequest inValue = new ICCA.Interface.PDFService.UploadDocRequest();
            inValue.Body = new ICCA.Interface.PDFService.UploadDocRequestBody();
            inValue.Body.message = message;
            ICCA.Interface.PDFService.UploadDocResponse retVal = ((ICCA.Interface.PDFService.DocumentTransferSoap)(this)).UploadDoc(inValue);
            return retVal.Body.response;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICCA.Interface.PDFService.RemoveDocResponse ICCA.Interface.PDFService.DocumentTransferSoap.RemoveDoc(ICCA.Interface.PDFService.RemoveDocRequest request) {
            return base.Channel.RemoveDoc(request);
        }
        
        public ICCA.Interface.PDFService.ResponseData RemoveDoc(string message) {
            ICCA.Interface.PDFService.RemoveDocRequest inValue = new ICCA.Interface.PDFService.RemoveDocRequest();
            inValue.Body = new ICCA.Interface.PDFService.RemoveDocRequestBody();
            inValue.Body.message = message;
            ICCA.Interface.PDFService.RemoveDocResponse retVal = ((ICCA.Interface.PDFService.DocumentTransferSoap)(this)).RemoveDoc(inValue);
            return retVal.Body.response;
        }
    }
}
