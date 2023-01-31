using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    public void UpdateMaterial(Material material) {
        _renderer.enabled = true;
        _renderer.material = material;
    }
}
