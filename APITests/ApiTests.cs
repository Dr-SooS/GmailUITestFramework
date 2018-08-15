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

        /// <summary>
        /// Verify status code
        /// </summary>
        [TestMethod]
        public void StatusCodeTest()
        {
            var response = Client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verify headers
        /// </summary>
        [TestMethod]
        public void HeaderTest()
        {
            var response = Client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        /// <summary>
        /// Verify content
        /// </summary>
        [TestMethod]
        public void ContentTest()
        {

            var response = Client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            var result = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(10, result.Count);
        }
    }
}
