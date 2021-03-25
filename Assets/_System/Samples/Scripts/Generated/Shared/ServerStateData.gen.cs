using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;

namespace SampesLogic.Shared
{
    public class ServerStateData
    {
        [JsonName("arrayServerElement")]
        public String[] ArrayServerElement;
        [JsonName("arrayServerElement1")]
        public Int32[] ArrayServerElement1;
        [JsonName("arrayServerElement2")]
        public Int64[] ArrayServerElement2;
        [JsonName("arrayServerElement3")]
        public Single[] ArrayServerElement3;
        [JsonName("arrayServerElement4")]
        public Double[] ArrayServerElement4;
        [JsonName("arrayServerElement5")]
        public Boolean[] ArrayServerElement5;
        [JsonName("arrayServerElement6")]
        public SimpleTestData[] ArrayServerElement6;
        [JsonName("arrayServerElement7")]
        public TestEnum[] ArrayServerElement7;
        [JsonName("serverElement")]
        public String ServerElement;
        [JsonName("serverElement1")]
        public Int32 ServerElement1;
        [JsonName("serverElement2")]
        public Int64 ServerElement2;
        [JsonName("serverElement3")]
        public Single ServerElement3;
        [JsonName("serverElement4")]
        public Double ServerElement4;
        [JsonName("serverElement5")]
        public Boolean ServerElement5;
        [JsonName("serverElement6")]
        public SimpleTestData ServerElement6;
        [JsonName("serverElement7")]
        public TestEnum ServerElement7;
    }
}

