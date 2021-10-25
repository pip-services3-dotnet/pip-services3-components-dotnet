using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PipServices3.Components.State
{
    public sealed class StateStoreFixture
    {
        public string KEY1 = "key1";
        public string KEY2 = "key2";

        public string VALUE1 = "value1";
        public string VALUE2 = "value2";

        private IStateStore _state;

        public StateStoreFixture(IStateStore state)
        {
            _state = state;
        }

        public async void TestSaveAndLoad()
        {
            await _state.SaveAsync(null, KEY1, VALUE1);
            await _state.SaveAsync(null, KEY2, VALUE2);

            var val = await this._state.LoadAsync<string>(null, KEY1);
            Assert.NotNull(val);
            Assert.Equal(VALUE1, val);

            var values = await this._state.LoadBulkAsync<string>(null, new List<string>() { KEY2 });
            Assert.Equal(1, values.Count);
            Assert.Equal(KEY2, values[0].Key);
            Assert.Equal(VALUE2, values[0].Value);
        }

        public async void TestDelete()
        {
            await this._state.SaveAsync(null, KEY1, VALUE1);

            await this._state.DeleteAsync<string>(null, KEY1);

            string val = await this._state.LoadAsync<string>(null, KEY1);
            
            Assert.Null(val);
        }
    }
}
