using UnityEngine;

// ！Cameraコンポーネントを持つゲームオブジェクトにアタッチしてください！
// ExecuteInEditMode            : プレイしなくても動作させる
// ImageEffectAllowedInSceneView: シーンビューにポストエフェクトを反映させる
[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class GaussianBlurEffectInserter : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    private int _Direction;

    private void Awake()
    {
        _Direction = Shader.PropertyToID("_Direction"); //プロパティIDを取得
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        /////////横幅を半分にしたレンダーテスクチャを作成（まだ、なにも描かれていない）
        var rth = RenderTexture.GetTemporary(src.width / 2, src.height);

        var h = new Vector2(1, 0); //ブラー方向のベクトル(U方向)
        _material.SetVector(_Direction, h); //シェーダー内の変数にブラー方向を設定

        Graphics.Blit(src, rth, _material);
        /////////

        /////////先のテクスチャサイズから、さらに縦半分にしたレンダーテスクチャを作成（まだ、なにも描かれていない）
        var rtv = RenderTexture.GetTemporary(rth.width, rth.height / 2);

        var v = new Vector2(0, 1);　//ブラー方向のベクトル(V方向)
        _material.SetVector(_Direction, v); //シェーダー内の変数にブラー方向を設定

        Graphics.Blit(rth, rtv, _material); // ブラー処理を行う
        /////////

        Graphics.Blit(rtv, dest, _material); //元サイズから1/4になったレンダーテクスチャを、元のサイズに戻す

        RenderTexture.ReleaseTemporary(rtv); //テンポラリレンダーテスクチャの開放
        RenderTexture.ReleaseTemporary(rth); //開放しないとメモリリークするので注意
        Debug.Log(99);
    }
}