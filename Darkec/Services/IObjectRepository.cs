using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;

namespace Darkec.Services
{
    public interface IObjectRepository<Key, Value>
    {
        public Dictionary<Key, Value> GetAllObjects();
        public void AddObject(Value value);
        public Value GetObject(Key id);
        public void UpdateObject(Value value);
        public void DeleteObject(Value value);
        public Dictionary<Key, Value> FilterObjects(string objectName);
    }
}
