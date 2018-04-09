using NUnit.Framework;
using PriceConverter.ModelProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceConverter.Tests.ModelProvider
{
    [TestFixture]
    public class PriceModelProviderTests
    {
        private IPriceModelProvider _modelProvider;

        [SetUp]
        public void SetUp()
        {
            _modelProvider = new PriceModelProvider();
        }

        [Test]
        public void GetModel_ValueIsZero_ShouldReturnDontHaveMoneyMessage()
        {          
            // Act
            var result = _modelProvider.GetModel(0);

            // Assert
            Assert.AreEqual("You don't have money", result.Price);
        }

        [Test]
        public void GetModel_HasSingleDollar_ShouldReturnOneDollar()
        {
            // Act
            var result = _modelProvider.GetModel(1);

            // Assert
            Assert.AreEqual("one dollar", result.Price);
        }

        [Test]
        public void GetModel_HasPluaralDollars_ShouldReturnDollars()
        {
            // Act
            var result = _modelProvider.GetModel(2);

            // Assert
            Assert.AreEqual("two dollars", result.Price);
        }

        [Test]
        public void GetModel_HasAllNumbers_ShouldReturnPropperConvertion()
        {
            // Act
            var result = _modelProvider.GetModel(2321);

            // Assert
            Assert.AreEqual("two thousand three hundred twenty-one dollars", result.Price);
        }

        [Test]
        public void GetModel_HasNoThousand_ShouldReturnPropperConvertion()
        {
            // Act
            var result = _modelProvider.GetModel(321);

            // Assert
            Assert.AreEqual("three hundred twenty-one dollars", result.Price);
        }

        [Test]
        public void GetModel_HasNoHundred_ShouldReturnPropperConvertion()
        {
            // Act
            var result = _modelProvider.GetModel(2021);

            // Assert
            Assert.AreEqual("two thousand twenty-one dollars", result.Price);
        }

        [Test]
        public void GetModel_HasOnlyTwoDigits_ShouldReturnPropperConvertion()
        {
            // Act
            var result = _modelProvider.GetModel(21);

            // Assert
            Assert.AreEqual("twenty-one dollars", result.Price);
        }


        [Test]
        public void GetModel_HasDecimal_ShouldReturnCents()
        {
            // Act
            var result = _modelProvider.GetModel(21.10m);

            // Assert
            Assert.AreEqual("twenty-one dollars and ten cents", result.Price);
        }

        [Test]
        public void GetModel_HasOnlyDecimalPart_ShouldReturnOnlyCents()
        {
            // Act
            var result = _modelProvider.GetModel(0.10m);

            // Assert
            Assert.AreEqual("ten cents", result.Price);
        }

        [Test]
        public void GetModel_HasOnly1DecimalPart_ShouldReturnSingleCent()
        {
            // Act
            var result = _modelProvider.GetModel(0.01m);

            // Assert
            Assert.AreEqual("one cent", result.Price);
        }
    }
}
