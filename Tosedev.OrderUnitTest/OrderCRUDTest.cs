using NUnit.Framework;
using System;
using Tosedev.Models;

namespace Tosedev.OrderUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Creat()
        {
            Adress adress = new Adress()
            {
                AdressLine = "Başakşehir/İstanul",
                City = "İstanbul",
                CityCode = 34300

            };
            Order order = new Order()
            {
                Adress = adress,
                CreatedAt = DateTime.Now,
                UpdatedAt=DateTime.Now,
                C
            };

            Assert.Pass();
        }
    }
}