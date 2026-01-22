
using UnityEngine;

public class ChangeColorCube : MonoBehaviour, IHitable
{
    private MeshRenderer m_renderer;

    private void Awake()
    {
        if (m_renderer == null) m_renderer = GetComponent<MeshRenderer>();
    }

    public void GetHit()
    {
        Color random_color = new Color(Random.value, Random.value, Random.value);

        m_renderer.material.color = random_color;
    }

}
