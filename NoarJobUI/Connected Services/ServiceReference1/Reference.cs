﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoarJobUI.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfNoarJob")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WUser", Namespace="http://schemas.datacontract.org/2004/07/WcfNoarJob")]
    [System.SerializableAttribute()]
    public partial class WUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NoarJobBL.Cv ChosenCvForJobField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NoarJobBL.Cv[] LstCvsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NoarJobBL.Cv ChosenCvForJob {
            get {
                return this.ChosenCvForJobField;
            }
            set {
                if ((object.ReferenceEquals(this.ChosenCvForJobField, value) != true)) {
                    this.ChosenCvForJobField = value;
                    this.RaisePropertyChanged("ChosenCvForJob");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CityName {
            get {
                return this.CityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CityNameField, value) != true)) {
                    this.CityNameField = value;
                    this.RaisePropertyChanged("CityName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NoarJobBL.Cv[] LstCvs {
            get {
                return this.LstCvsField;
            }
            set {
                if ((object.ReferenceEquals(this.LstCvsField, value) != true)) {
                    this.LstCvsField = value;
                    this.RaisePropertyChanged("LstCvs");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((this.UserIDField.Equals(value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IWcfNoarJob")]
    public interface IWcfNoarJob {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/GetData", ReplyAction="http://tempuri.org/IWcfNoarJob/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/GetData", ReplyAction="http://tempuri.org/IWcfNoarJob/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IWcfNoarJob/GetDataUsingDataContractResponse")]
        NoarJobUI.ServiceReference1.CompositeType GetDataUsingDataContract(NoarJobUI.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IWcfNoarJob/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<NoarJobUI.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(NoarJobUI.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/CreateUser", ReplyAction="http://tempuri.org/IWcfNoarJob/CreateUserResponse")]
        NoarJobUI.ServiceReference1.WUser CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/CreateUser", ReplyAction="http://tempuri.org/IWcfNoarJob/CreateUserResponse")]
        System.Threading.Tasks.Task<NoarJobUI.ServiceReference1.WUser> CreateUserAsync(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/UserLogin", ReplyAction="http://tempuri.org/IWcfNoarJob/UserLoginResponse")]
        NoarJobUI.ServiceReference1.WUser UserLogin(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfNoarJob/UserLogin", ReplyAction="http://tempuri.org/IWcfNoarJob/UserLoginResponse")]
        System.Threading.Tasks.Task<NoarJobUI.ServiceReference1.WUser> UserLoginAsync(string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfNoarJobChannel : NoarJobUI.ServiceReference1.IWcfNoarJob, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfNoarJobClient : System.ServiceModel.ClientBase<NoarJobUI.ServiceReference1.IWcfNoarJob>, NoarJobUI.ServiceReference1.IWcfNoarJob {
        
        public WcfNoarJobClient() {
        }
        
        public WcfNoarJobClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfNoarJobClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfNoarJobClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfNoarJobClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public NoarJobUI.ServiceReference1.CompositeType GetDataUsingDataContract(NoarJobUI.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<NoarJobUI.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(NoarJobUI.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public NoarJobUI.ServiceReference1.WUser CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName) {
            return base.Channel.CreateUser(email, userPassword, firstName, lastName, phone, cityID, cityName);
        }
        
        public System.Threading.Tasks.Task<NoarJobUI.ServiceReference1.WUser> CreateUserAsync(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName) {
            return base.Channel.CreateUserAsync(email, userPassword, firstName, lastName, phone, cityID, cityName);
        }
        
        public NoarJobUI.ServiceReference1.WUser UserLogin(string email, string password) {
            return base.Channel.UserLogin(email, password);
        }
        
        public System.Threading.Tasks.Task<NoarJobUI.ServiceReference1.WUser> UserLoginAsync(string email, string password) {
            return base.Channel.UserLoginAsync(email, password);
        }
    }
}