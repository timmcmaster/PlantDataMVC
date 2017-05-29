using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace UnitTest.Utils.TestData
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public static class DomainTestData
    {
        #region Public Methods

        /// <summary>
        /// Creates a random Plant, that should be valid.
        /// </summary>
        /// <returns></returns>
        public static IList<Plant> GenerateRandomPlantList(int length)
        {
            var plantList = new List<Plant>();

            for (int i = 0; i < length; i++)
            {
                plantList.Add(GenerateRandomPlant());
            }

            return plantList;
        }

        /// <summary>
        /// Creates a random Plant, that should be valid.
        /// </summary>
        /// <returns></returns>
        public static Plant GenerateRandomPlant()
        {
            var rnd = SeedRandom();
            var plant = new Plant()
                               {
                                   Id = CommonTestData.GeneratRandomInt(),
                                   CommonName = CommonTestData.GenerateRandomAlphabetString(50),
                                   Description = CommonTestData.GenerateRandomAlphabetString(200),
                                   PropagationTime = CommonTestData.GeneratRandomInt(),
                                   Native = CommonTestData.GenerateRandomBoolean(),
                                   GenusLatinName = CommonTestData.GenerateRandomAlphabetString(10),
                                   SpeciesLatinName = CommonTestData.GenerateRandomAlphabetString(10)
                               };
            return plant;
        }

        ///// <summary>
        ///// Creates a random address, that should be valid.
        ///// </summary>
        ///// <returns></returns>
        //public static Address GenerateRandomBusinessAddress()
        //{
        //    var address = GenerateRandomAddress();
        //    address.AddressType = AddressType.Business;
        //    return address;
        //}

        //public static CompanyDetail GenerateRandomCompanyDetail()
        //{
        //    return new CompanyDetail
        //               {
        //                   Abn = GeneratRandomNumber(11),
        //                   Acn = GeneratRandomNumber(9),
        //                   CompanyName = GenerateRandomAlphabetString(30),
        //                   TradingName = GenerateRandomAlphabetString(30)
        //               };
        //}

        //public static Contact GenerateRandomContact()
        //{
        //    return new Contact
        //               {
        //                   FirstName = GenerateRandomAlphabetString(30),
        //                   LastName = GenerateRandomAlphabetString(30),
        //                   Email = GenerateRandomEmail(),
        //                   PhoneNumber = GenerateRandomPhoneNumber(),
        //                   Title = RandomTitle()
        //               };
        //}

        //public static ContactDetail GenerateRandomContactDetail()
        //{
        //    return new ContactDetail
        //               {
        //                   Address = GenerateRandomPostalAddress(),
        //                   BusinessPhoneNumber = GenerateRandomPhoneNumber(),
        //                   ContactName = GenerateRandomEmployerName(),
        //                   EmailAddress = GenerateRandomEmail(),
        //                   FaxNumber = GenerateRandomPhoneNumber(),
        //                   MobileNumber = GenerateRandomMobileNumber(),
        //                   IsDefaultLocation = true,
        //               };
        //}

        //public static Name GenerateRandomName()
        //{
        //    return new Name
        //               {
        //                   GivenName = GenerateRandomAlphabetString(30),
        //                   Surname = GenerateRandomAlphabetString(30),
        //                   Title = RandomTitle()
        //               };
        //}

        //public static Name GenerateRandomEmployerName()
        //{
        //    return new Name
        //    {
        //        GivenName = GenerateRandomAlphabetString(30),
        //        Surname = GenerateRandomAlphabetString(30),
        //        Title = RandomEmployerTitle()
        //    };
        //}

        //public static PaymentDetail GenerateRandomPaymentDetail()
        //{
        //    return new PaymentDetail
        //               {
        //                   BankAccount = GenerateRandomBankAccount(),
        //                   ContributionFrequency = RandomContributionFrequency(),
        //                   ContributionPaymentOption = RandomContributionPaymentOption(),
        //                   ContributionStartDate = DateTime.Today.AddMonths(-1),
        //                   ClearingHouse = false
        //               };
        //}

        ///// <summary>
        ///// Creates a random address, that should be valid.
        ///// </summary>
        ///// <returns></returns>
        //public static Address GenerateRandomPostalAddress()
        //{
        //    var address = GenerateRandomAddress();
        //    address.AddressType = AddressType.Mailing;
        //    return address;
        //}

        ///// <summary>
        ///// Creates a random address, that is known to be valid.
        ///// </summary>
        ///// <returns></returns>
        //public static Address GenerateValidProspectAddress()
        //{
        //    var rnd = SeedRandom();
        //    return new Address
        //               {
        //                   Country = new Country { Code = "AND", Name = "ANDORRA" },
        //                   Line1 = "100 smith st",
        //                   Line2 = "Second line",
        //                   Line3 = "Third line",
        //                   Postcode = "4000",
        //                   State = new State { Code = "WA", Name = "Western Australia" },
        //                   Suburb = "Brisbane"
        //               };
        //}

        //public static ContributionFrequency RandomContributionFrequency()
        //{
        //    var contributionFrequency = new List<ContributionFrequency>();
        //    contributionFrequency.Add(new ContributionFrequency { Code = "1", Name = "Once a year" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "2", Name = "Twice a year" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "3", Name = "Quarterly" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "4", Name = "Once a month" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "5", Name = "Twice a month" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "6", Name = "Fortnightly" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "7", Name = "Weekly" });
        //    contributionFrequency.Add(new ContributionFrequency { Code = "8", Name = "Daily" });

        //    return contributionFrequency.OrderBy(x => Guid.NewGuid()).First();
        //}

        //public static ContributionPaymentOption RandomContributionPaymentOption()
        //{
        //    var contributionPaymentOptions = new List<ContributionPaymentOption>();
        //    contributionPaymentOptions.Add(new ContributionPaymentOption { Code = "E", Name = "Sunsuper Webpay" });
        //    contributionPaymentOptions.Add(new ContributionPaymentOption { Code = "L", Name = "Cheque" });
        //    contributionPaymentOptions.Add(new ContributionPaymentOption { Code = "N", Name = "BPAY" });
        //    contributionPaymentOptions.Add(new ContributionPaymentOption { Code = "W", Name = "Direct Credit" });

        //    return contributionPaymentOptions.OrderBy(x => Guid.NewGuid()).First();
        //}

        //public static Country RandomCountry()
        //{
        //    var countrys = new List<Country>();
        //    countrys.Add(new Country { Code = "AND", Name = "ANDORRA" });
        //    countrys.Add(new Country { Code = "SLB", Name = "SOLOMON ISLANDS" });
        //    countrys.Add(new Country { Code = "SWZ", Name = "SWAZILAND" });
        //    countrys.Add(new Country { Code = "TWN", Name = "TAIWAN" });
        //    countrys.Add(new Country { Code = "MKD", Name = "MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF" });
        //    countrys.Add(new Country { Code = "IRN", Name = "IRAN (ISLAMIC REPUBLIC OF)" });
        //    countrys.Add(new Country { Code = "COD", Name = "CONGO, Democratic Republic of (was Zaire)" });

        //    return countrys.OrderBy(x => Guid.NewGuid()).First();
        //}

        //public static MailingCode RandomMailingCode()
        //{
        //    var mailingCodes = new List<MailingCode>();
        //    mailingCodes.Add(new MailingCode { Code = "VS", Name = "VS" });
        //    mailingCodes.Add(new MailingCode { Code = "ER", Name = "ER" });
        //    mailingCodes.Add(new MailingCode { Code = "UH", Name = "UH" });
        //    mailingCodes.Add(new MailingCode { Code = "VH", Name = "VH" });

        //    return mailingCodes.OrderBy(x => Guid.NewGuid()).First();
        //}

        //public static State RandomState()
        //{
        //    var states = new List<State>();
        //    states.Add(new State { Code = "ACT", Name = "Australian Capital Territory" });
        //    states.Add(new State { Code = "NSW", Name = "New South Wales" });
        //    states.Add(new State { Code = "NT", Name = "Northern Territory" });
        //    states.Add(new State { Code = "QLD", Name = "Queensland" });
        //    states.Add(new State { Code = "SA", Name = "South Australia" });
        //    states.Add(new State { Code = "TAS", Name = "Tasmania" });
        //    states.Add(new State { Code = "WA", Name = "Western Australia" });
        //    states.Add(new State { Code = "VIC", Name = "Victoria" });

        //    return states.OrderBy(x => Guid.NewGuid()).First();
        //}

        //public static Title RandomTitle()
        //{
        //    var titles = new List<Title>();
        //    titles.Add(new Title("MR", "MR"));
        //    titles.Add(new Title("MRS", "MRS"));
        //    titles.Add(new Title("MISS", "MISS"));
        //    titles.Add(new Title("MS", "MS"));
        //    titles.Add(new Title("DR", "DR"));

        //    return titles.OrderBy(x => Guid.NewGuid()).First();
        //}

        //public static Title RandomEmployerTitle()
        //{
        //    var titles = new List<Title>();
        //    titles.Add(new Title("MR", "Mr"));
        //    titles.Add(new Title("MRS", "Mrs"));
        //    titles.Add(new Title("MISS", "Miss"));
        //    titles.Add(new Title("MS", "Ms"));
        //    titles.Add(new Title("DR", "Doctor"));

        //    return titles.OrderBy(x => Guid.NewGuid()).First();
        //}

        #endregion

        #region Methods

        private static Random SeedRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        #endregion
    }
}