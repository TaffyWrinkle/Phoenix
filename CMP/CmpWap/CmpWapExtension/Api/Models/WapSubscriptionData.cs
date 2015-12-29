//*****************************************************************************
// File: WapSubscriptionData.cs
// Project: Microsoft.WindowsAzurePack.CmpWapExtension.Api
// Purpose: Model for WapSubscriptionData
// Copyright (c) Microsoft Corporation.  All rights reserved.
//*****************************************************************************
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzurePack.CmpWapExtension.Api.Models
{
    public partial class WapSubscriptionData
    {
        public int Id { get; set; }
        public string WapSubscriptionID { get; set; }
        public int DefaultObjectCreationGroupID { get; set; }
        public string Config { get; set; }
        public string TagData { get; set; }
        public Nullable<int> TagId { get; set; }
        public bool IsActive { get; set; }
    }
}
