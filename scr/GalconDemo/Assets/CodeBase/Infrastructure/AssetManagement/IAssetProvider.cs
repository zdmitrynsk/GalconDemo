using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
    GameObject Instatiate(string path);
    GameObject Instatiate(string path, Vector3 at);
    GameObject Instatiate(string path, Transform parent);
  }
}