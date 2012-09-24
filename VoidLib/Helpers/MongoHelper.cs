using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace BlackRain.Helpers
{
    class MongoHelper
    {
        public static MongoServer server;
        public static MongoDatabase database;

        private void connect()
        {
            server = MongoServer.Create("mongodb://50.115.175.42:27020");
            database = server.GetDatabase("void");
        }
    }
}
