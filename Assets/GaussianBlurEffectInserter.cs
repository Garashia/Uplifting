using UnityEngine;

// �ICamera�R���|�[�l���g�����Q�[���I�u�W�F�N�g�ɃA�^�b�`���Ă��������I
// ExecuteInEditMode            : �v���C���Ȃ��Ă����삳����
// ImageEffectAllowedInSceneView: �V�[���r���[�Ƀ|�X�g�G�t�F�N�g�𔽉f������
[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class GaussianBlurEffectInserter : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    private int _Direction;

    private void Awake()
    {
        _Direction = Shader.PropertyToID("_Direction"); //�v���p�e�BID���擾
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        /////////�����𔼕��ɂ��������_�[�e�X�N�`�����쐬�i�܂��A�Ȃɂ��`����Ă��Ȃ��j
        var rth = RenderTexture.GetTemporary(src.width / 2, src.height);

        var h = new Vector2(1, 0); //�u���[�����̃x�N�g��(U����)
        _material.SetVector(_Direction, h); //�V�F�[�_�[���̕ϐ��Ƀu���[������ݒ�

        Graphics.Blit(src, rth, _material);
        /////////

        /////////��̃e�N�X�`���T�C�Y����A����ɏc�����ɂ��������_�[�e�X�N�`�����쐬�i�܂��A�Ȃɂ��`����Ă��Ȃ��j
        var rtv = RenderTexture.GetTemporary(rth.width, rth.height / 2);

        var v = new Vector2(0, 1);�@//�u���[�����̃x�N�g��(V����)
        _material.SetVector(_Direction, v); //�V�F�[�_�[���̕ϐ��Ƀu���[������ݒ�

        Graphics.Blit(rth, rtv, _material); // �u���[�������s��
        /////////

        Graphics.Blit(rtv, dest, _material); //���T�C�Y����1/4�ɂȂ��������_�[�e�N�X�`�����A���̃T�C�Y�ɖ߂�

        RenderTexture.ReleaseTemporary(rtv); //�e���|���������_�[�e�X�N�`���̊J��
        RenderTexture.ReleaseTemporary(rth); //�J�����Ȃ��ƃ��������[�N����̂Œ���
        Debug.Log(99);
    }
}