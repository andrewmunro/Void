using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace VoidLib.Helpers
{
    static class MongoHelper
    {
        public static MongoServer server;
        public static MongoDatabase database;
        public static string dbName = "void";
        public static string dbURL = "mongodb://50.115.175.42:27020";
        public static string fileName = @"C:\Users\Andrew\Desktop\Void\VoidRadar\VoidRadarContent\Tiles\East\map17_37.png";

        static void connect()
        {
            server = MongoServer.Create(dbURL);
            database = server.GetDatabase("void");
            if (!database.CollectionExists(dbName))
            {
                database.CreateCollection(dbName);
            }
        }

        static void upload()
        {
            /*
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var gridFsInfo = database.GridFS.Upload(fs, fileName);
                var fileId = gridFsInfo.Id;

                ObjectId oid = new ObjectId((string)fileId);
                var file = database.GridFS.FindOne(Query.EQ("id", oid));

                using (var stream = file.OpenRead())
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    using (var newFs = new FileStream(newFileName, FileMode.Create))
                    {
                        newFs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
             * */
        }
    }
}
