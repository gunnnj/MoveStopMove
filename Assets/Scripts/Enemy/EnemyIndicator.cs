using UnityEngine;
using UnityEngine.UI;

public class EnemyIndicator : MonoBehaviour
{
    public Transform enemy;       
    public Image arrow;           


    void Update()
    {
        if(PlayerMove.player!=null){
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(enemy.position);
            bool isOutside = screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;

            if (isOutside)
            {
                arrow.gameObject.SetActive(true); // Hiển thị mũi tên

                // Tính toán hướng từ tâm camera (hoặc player) đến enemy
                Vector3 direction = enemy.position - PlayerMove.player.transform.position;
                // Vector3 direction = enemy.position - Camera.main.transform.position;
                float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

                Vector3 edgePosition = new Vector3(
                    Mathf.Clamp(screenPoint.x, 0.05f, 0.95f), // Giới hạn vị trí x
                    Mathf.Clamp(screenPoint.y, 0.05f, 0.95f), // Giới hạn vị trí y
                    0
                );

                // Cập nhật vị trí và góc của mũi tên
                arrow.transform.position = new Vector3(edgePosition.x * Screen.width, edgePosition.y * Screen.height, 0);
                arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90)); // Quay mũi tên
            }
            else
            {
                arrow.gameObject.SetActive(false); // Ẩn mũi tên
            }
        }
        
    }
}
