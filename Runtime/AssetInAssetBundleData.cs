using System;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Kogane
{
    /// <summary>
    /// アセットバンドルに含まれるアセットのデータを管理する構造体
    /// </summary>
    [Serializable]
    public struct AssetInAssetBundleData
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private string a; // アセットのパス
        [SerializeField] private string b; // アセットが含まれるアセットバンドルの名前

        //================================================================================
        // プロパティ
        //================================================================================
        public string AssetPath       => a;
        public string AssetBundleName => b;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AssetInAssetBundleData
        (
            string assetPath,
            string assetBundleName
        )
        {
            a = assetPath;
            b = assetBundleName;
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