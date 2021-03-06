using System;
using System.Collections.Generic;

namespace CmpServiceLib.Models
{
    public partial class VmDeploymentRequests_BackUP
    {
        public int ID { get; set; }
        public string RequestName { get; set; }
        public string RequestDescription { get; set; }
        public string ParentAppName { get; set; }
        public string ParentAppID { get; set; }
        public string RequestType { get; set; }
        public string TargetServiceProviderType { get; set; }
        public string TargetLocation { get; set; }
        public string TargetLocationType { get; set; }
        public string TargetAccount { get; set; }
        public string TargetAccountType { get; set; }
        public string TargetAccountCreds { get; set; }
        public string VmSize { get; set; }
        public string TagData { get; set; }
        public string Config { get; set; }
        public string TargetVmName { get; set; }
        public string SourceServerName { get; set; }
        public string SourceVhdFilesCSV { get; set; }
        public string WhoRequested { get; set; }
        public Nullable<System.DateTime> WhenRequested { get; set; }
        public string ExceptionMessage { get; set; }
        public Nullable<System.DateTime> LastStatusUpdate { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Nullable<int> AftsID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string TargetServicename { get; set; }
        public string ServiceProviderStatusCheckTag { get; set; }
        public Nullable<int> TagID { get; set; }
        public Nullable<int> ServiceProviderAccountID { get; set; }
        public Nullable<bool> OverwriteExisting { get; set; }
        public Nullable<System.DateTime> CurrentStateStartTime { get; set; }
        public Nullable<int> CurrentStateTryCount { get; set; }
        public string Warnings { get; set; }
        public string ValidationResults { get; set; }
        public string SourceServerRegion { get; set; }
        public string ExceptionTypeCode { get; set; }
        public string LastState { get; set; }
        public string ServiceProviderResourceGroup { get; set; }
        public string ConfigOriginal { get; set; }
    }
}
