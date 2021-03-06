// <copyright file="IAddressDataView.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GrampsView.Data.DataView
{
    using System.Collections.Generic;

    using GrampsView.Data.Collections;

    using GrampsView.Data.Model;
    using GrampsView.Data.Repositories;

    /// <summary>
    /// Interface for the Address Repository.
    /// </summary>
    public interface IAddressDataView : IDataViewBase<AddressModel, HLinkAdressModel, HLinkOCAddressModelCollection>
    {
        /// <summary>
        /// Gets or sets the specified address hlink string.
        /// </summary>
        /// <value>
        /// The citation data.
        /// </value>
        RepositoryModelDictionary<AddressModel, HLinkAdressModel> AddressData
        {
            get;
        }

        /// <summary>
        /// Gets the data default sort.
        /// </summary>
        /// <value>
        /// The data default sort.
        /// </value>
        new IReadOnlyList<AddressModel> DataDefaultSort { get; }

        /// <summary>
        /// Gets all as hlink.
        /// </summary>
        /// <returns>
        /// Hlink of Address model collection.
        /// </returns>
        HLinkOCAddressModelCollection GetAllAsHLink();

        /// <summary>
        /// HLink collection sort.
        /// </summary>
        /// <param name="collectionArg">
        /// The collection argument.
        /// </param>
        /// <returns>
        /// </returns>
        new HLinkOCAddressModelCollection HLinkCollectionSort(HLinkOCAddressModelCollection collectionArg);
    }
}