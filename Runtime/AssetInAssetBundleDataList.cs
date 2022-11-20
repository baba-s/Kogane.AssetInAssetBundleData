using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Kogane
{
    /// <summary>
    /// アセットバンドルに含まれるすべてのアセットのデータを管理する構造体
    /// </summary>
    [Serializable]
    public struct AssetInAssetBundleDataList
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private AssetInAssetBundleData[] a;

        //================================================================================
        // 変数
        //================================================================================
        private Dictionary<string, string> m_table;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AssetInAssetBundleDataList( AssetInAssetBundleData[] datas )
        {
            a       = datas;
            m_table = new( a.Length );
        }

        /// <summary>
        /// 指定されたアセットのパスに紐づくデータを返します
        /// </summary>
        public string GetAssetBundleNameByAssetPath( string assetPath )
        {
            m_table ??= new( a.Length );
            if ( m_table.TryGetValue( assetPath, out var result ) ) return result;
            var assetBundleName = a.First( x => x.AssetPath == assetPath ).AssetBundleName;
            m_table[ assetPath ] = assetBundleName;
            return assetBundleName;
        }

        /// <summary>
        /// JSON 形式の文字列に変換して返します
        /// </summary>
        public override string ToString()
        {
            return JsonUtility.ToJson( this, true );
        }
    }
}