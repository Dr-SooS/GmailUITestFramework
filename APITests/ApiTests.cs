using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using APITests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace APITests
{
    [TestClass]
    public class ApiTests
    {
        public HttpClient Client = new HttpClient();

        [TestMethod]
        public void StatusCodeTest()
        {
            var response = Client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void HeaderTest()
        {
            var response = Client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [TestMethod]
        public void ContentTest()
        {

            var response = Client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            var result = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(10, result.Count);
        }
    }
}
