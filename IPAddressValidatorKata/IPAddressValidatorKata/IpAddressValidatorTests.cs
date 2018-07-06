using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IPAddressValidatorKata
{
    [TestFixture]
    public class IpAddressValidatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void ValidateIpV4Address_GivenInvalidIpAddress_ShouldReturnFalse(string input)
        {
            //Arrange
            var sut = new IpAddressValidator();
            
            //Act
            var actual = sut.ValidateIpV4Address(input);

            //Assert
            var expected = false;
            Assert.AreEqual(expected,actual);
        }
        [TestCase("1.1.1.1",true)]
        [TestCase("192.168.1.1",true)]
        [TestCase("10.0.0.1",true)]
        public void ValidateIpV4Address_GivenValidIpAddress_ShouldReturnTrue(string input,bool expected)
        {
            //Arrange
            var sut = new IpAddressValidator();

            //Act
            var actual = sut.ValidateIpV4Address(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("0.0.0.0",false)]
        [TestCase("255.255.255.255",false)]
        [TestCase("10.0.1", false)]
        public void ValidateIpV4Address_GivenValidIpAddressThatCannotHost_ShouldReturnFalse(string input, bool expected)
        {
            //Arrange
            var sut = new IpAddressValidator();

            //Act
            var actual = sut.ValidateIpV4Address(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("127.0.0.1", true)]
        [TestCase("586.921.0", false)]
        [TestCase("125.1.568.258", true)]
        public void ValidateIpV4Address_GivenValidIpAddressThatCanHostAndCannotHost_ShouldReturnFalse(string input, bool expected)
        {
            //Arrange
            var sut = new IpAddressValidator();

            //Act
            var actual = sut.ValidateIpV4Address(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
