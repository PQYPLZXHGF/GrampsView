﻿//-----------------------------------------------------------------------
//
// Handles GRAMPS Address fields
//
// <copyright file="AddressModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GrampsView.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using static GrampsView.Common.CommonEnums;

    //// gramps XML 1.71
    ////
    //// style
    //// name
    //// value
    //// range
    /// </summary>
    public class StyledTextModel : ModelBase, IStyledTextModel, IComparable<StyledTextModel>, IEquatable<StyledTextModel>
    {
        public StyledTextModel()
        {
        }

        [DataMember]
        public List<StyledTextRangeModel> GRange { get; set; }
                                                = new List<StyledTextRangeModel>();

        [DataMember]
        public TextStyle GStyle { get; set; }
                                = TextStyle.unknown;

        [DataMember]
        public string GValue { get; set; }

        public int CompareTo(StyledTextModel other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return GetDefaultText.CompareTo(other.GetDefaultText);
        }

        public bool Equals(StyledTextModel other)
        {
            if (other is null)
            {
                return false;
            }

            if (GetDefaultText == other.GetDefaultText)
            {
                return true;
            }

            return false;
        }
    }
}