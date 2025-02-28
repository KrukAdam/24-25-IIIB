using UnityEngine;

namespace Controllers
{
    public class PortalController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("loadingLevel");
        }
    }

}