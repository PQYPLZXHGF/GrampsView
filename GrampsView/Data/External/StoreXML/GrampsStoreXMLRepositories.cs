﻿//-----------------------------------------------------------------------
//
// Storage routines for GrampsStoreXML
//
// <copyright file="GrampsStoreXMLRepositories.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GrampsView.Data.ExternalStorageNS
{
    using GrampsView.Data.DataView;
    using GrampsView.Data.Model;
    using GrampsView.Data.Repository;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// </summary>
    public partial class GrampsStoreXML : IGrampsStoreXML
    {
        /// <summary>
        /// load events from external storage.
        /// </summary>
        /// <param name="eventRepository">
        /// The event repository.
        /// </param>
        /// <returns>
        /// Flag of loaded successfully.
        /// </returns>
        public async Task LoadRepositoriesAsync()
        {
            await DataStore.CN.MajorStatusAdd(nameof(LoadRepositoriesAsync)).ConfigureAwait(false);

            try
            {
                // Run query
                var de =
                    from el in localGrampsXMLdoc.Descendants(ns + "repository")
                    select el;

                foreach (XElement pRepositoryElement in de)
                {
                    RepositoryModel loadRepository = DV.RepositoryDV.NewModel();

                    // SecondaryColor attributes
                    loadRepository.LoadBasics(GetBasics(pRepositoryElement));
                    //loadRepository.Id = (string)pRepositoryElement.Attribute("id");
                    //loadRepository.Change = GetDateTime(pRepositoryElement, "change");
                    //loadRepository.Priv = SetPrivateObject((string)pRepositoryElement.Attribute("priv"));
                    //loadRepository.Handle = (string)pRepositoryElement.Attribute("handle");

                    if (loadRepository.Id == "R0000")
                    {
                    }

                    // Repository fields
                    loadRepository.GRName = GetElement(pRepositoryElement, "rname");
                    loadRepository.GType = GetElement(pRepositoryElement, "type");
                    loadRepository.GAddress = GetAddressCollection(pRepositoryElement);
                    loadRepository.GURL = GetURLCollection(pRepositoryElement);
                    loadRepository.GNoteRefCollection = GetNoteCollection(pRepositoryElement);
                    loadRepository.GTagRefCollection = GetTagCollection(pRepositoryElement);

                    // save the event
                    DV.RepositoryDV.RepositoryData.Add(loadRepository);
                }
            }
            catch (Exception e)
            {
                // TODO handle this
                await DataStore.CN.MajorStatusAdd(e.Message).ConfigureAwait(false);

                throw;
            }

            await DataStore.CN.MajorStatusDelete().ConfigureAwait(false);
            return;
        }
    }
}