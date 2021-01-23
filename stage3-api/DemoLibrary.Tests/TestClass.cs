using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;

namespace DemoLibrary.Tests
{
    public class TestClass
    {
        [Fact]
        public void Add_ValueShoudCalculate()
        {
            //Arrange
            double expected = 5;

            //Act
            double actual = Class1.Add(3, 2);

            //Assert
            Assert.Equal(expected, actual); 
        }
    }
}
