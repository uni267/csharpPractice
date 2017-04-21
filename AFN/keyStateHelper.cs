using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFN
{
    public class KeyStateHelper
    {
        /// <summary>
        /// 押下確認対象
        private List<Keys> _keyPressedList = new List<Keys>();

        /// <summary>
        /// キー押下状態登録
        /// </summary>
        /// <param name="key"></param>
        public void RegisterPressedKey(Keys key)
        {
            if(!_keyPressedList.Contains(key))
                _keyPressedList.Add(key);
        }
        /// <summary>
        /// キー押下状態解除
        /// </summary>
        /// <param name="key"></param>
        public void UnregisterPressedKey(Keys key)
        {
            _keyPressedList.Remove(key);
            Console.Write(key);

        }
        /// <summary>
        /// キー押下状態のクリア
        /// </summary>
        public void ClearPressedKey()
        {
            _keyPressedList.Clear();
        }
        /// <summary>
        /// 指定キーが押されているかどうかを取得する。
        /// </summary>
        /// <param name="keyList"></param>
        /// <returns></returns>
        public bool IsPressedKey(Keys[] keyList)
        {
            foreach (Keys key in keyList)
            {
                if (!_keyPressedList.Contains(key)) return false;
            }
            return true;
        }

        public bool IsPressedKey(Keys key)
        {
            return _keyPressedList.Contains(key);
        }
    }
}
