using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Core.Helper
{
    public class LiteDBHelper
    {
        public static void RegisterDateTimeType()
        {
            BsonMapper.Global.RegisterType<DateTimeOffset>
            (
                serialize: obj =>
                {
                    var doc = new BsonDocument();
                    doc["DateTime"] = obj.DateTime.Ticks;
                    doc["Offset"] = obj.Offset.Ticks;
                    return doc;
                },
                deserialize: doc => new DateTimeOffset(doc["DateTime"].AsInt64, new TimeSpan(doc["Offset"].AsInt64))
            );
        }
    }
}
