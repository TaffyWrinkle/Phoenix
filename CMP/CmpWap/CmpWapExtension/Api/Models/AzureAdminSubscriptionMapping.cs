﻿//*****************************************************************************
// File: AzureAdminSubscriptionMapping.cs
// Project: Microsoft.WindowsAzurePack.CmpWapExtension.Api
// Purpose: Model for mapping to Azure Admin Subscription to the plan
// Copyright (c) Microsoft Corporation.  All rights reserved.
//*****************************************************************************

using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzurePack.CmpWapExtension.Api.Models
{
    public partial class AzureAdminSubscriptionMapping
    {
        public int Id { get; set; }
        public int SubId { get; set; }
        public string PlanId { get; set; }
        public bool IsActive { get; set; }
    }
}
