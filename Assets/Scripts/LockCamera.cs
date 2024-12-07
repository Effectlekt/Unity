using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField]
    private float x, y;
    private void Awake() {
        x = 7;
        y = 7;
    }
    void Update()
    {
        float xx, yy, zz;
        Vector3 pos = this.transform.position;
        xx = this.transform.position.x;
        yy = this.transform.position.y;
        zz = this.transform.position.z;

        if (xx > x){
            pos = new Vector3(x, yy, zz);
        }
        if (xx < -x){
            pos = new Vector3(-x, yy, zz);
        }
        if (yy > y){
            pos = new Vector3(xx, y, zz);
        }
        if (yy < -y){
            pos = new Vector3(xx, -y, zz);
        }
        this.transform.position = pos;
    }
}
