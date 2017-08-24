using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TxoooProductUpload.Common
{
    /// <summary>
    /// 序列化对象
    /// </summary>
    public class Serialize
    {
        static string _root = System.Reflection.Assembly.GetExecutingAssembly().GetLocation();
        static string _dataRoot = Path.Combine(_root, "data");

        /// <summary>
        /// 序列化为对象 用二进制格式序列化
        /// </summary>
        /// <param name="objname">存储的文件对象</param>
        /// <param name="obj">要序列话的对象</param>
        public static void BinarySerialize(string objname, object obj)
        {
            try
            {
                string filename = Path.Combine(_dataRoot, objname);
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 用二进制格式序列化
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从二进制文件中反序列化
        /// </summary>
        /// <param name="objname">存储文件对象</param>
        /// <returns>反序列化对象</returns>
        public static object BinaryDeserialize(string objname)
        {
            IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            object obj;
            string filename = Path.Combine(_dataRoot, objname);
            if (!File.Exists(filename))
            {
                throw new Exception("在反序列化之前,请先序列化");
            }
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }
    }
}
