﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VoucherRedemptionMobile.IntegrationTests.Common
{
    using System.Linq;
    using Shouldly;
    using TechTalk.SpecFlow;

    public class TestingContext
    {
        #region Fields

        /// <summary>
        /// The clients
        /// </summary>
        private readonly List<ClientDetails> Clients;

        /// <summary>
        /// The estates
        /// </summary>
        private readonly List<EstateDetails> Estates;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestingContext"/> class.
        /// </summary>
        public TestingContext()
        {
            this.Estates = new List<EstateDetails>();
            this.Clients = new List<ClientDetails>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public String AccessToken { get; set; }

        //public NlogLogger Logger { get; set; }

        /// <summary>
        /// Gets or sets the docker helper.
        /// </summary>
        /// <value>
        /// The docker helper.
        /// </value>
        public VoucherRedemptionMobileDockerHelper DockerHelper { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the client details.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="grantType">Type of the grant.</param>
        public void AddClientDetails(String clientId,
                                     String clientSecret,
                                     String grantType)
        {
            this.Clients.Add(ClientDetails.Create(clientId, clientSecret, grantType));
        }

        /// <summary>
        /// Adds the estate details.
        /// </summary>
        /// <param name="estateId">The estate identifier.</param>
        /// <param name="estateName">Name of the estate.</param>
        public void AddEstateDetails(Guid estateId,
                                     String estateName)
        {
            this.Estates.Add(EstateDetails.Create(estateId, estateName));
        }

        /// <summary>
        /// Gets the client details.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public ClientDetails GetClientDetails(String clientId)
        {
            ClientDetails clientDetails = this.Clients.SingleOrDefault(c => c.ClientId == clientId);

            clientDetails.ShouldNotBeNull();

            return clientDetails;
        }

        /// <summary>
        /// Gets the estate details.
        /// </summary>
        /// <param name="tableRow">The table row.</param>
        /// <returns></returns>
        public EstateDetails GetEstateDetails(TableRow tableRow)
        {
            String estateName = SpecflowTableHelper.GetStringRowValue(tableRow, "EstateName");

            EstateDetails estateDetails = this.Estates.SingleOrDefault(e => e.EstateName == estateName);

            estateDetails.ShouldNotBeNull();

            return estateDetails;
        }

        /// <summary>
        /// Gets the estate details.
        /// </summary>
        /// <param name="estateName">Name of the estate.</param>
        /// <returns></returns>
        public EstateDetails GetEstateDetails(String estateName)
        {
            EstateDetails estateDetails = this.Estates.SingleOrDefault(e => e.EstateName == estateName);

            estateDetails.ShouldNotBeNull();

            return estateDetails;
        }

        #endregion
    }
}
