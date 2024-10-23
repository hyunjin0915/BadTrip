using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransfrom;

    private Vector3 cameraStartPos;
    private float distance;
    
    private Material[] materials;
    private float[] layerMoveSpeed;

    [SerializeField][Range(0.01f, 1.0f)]
    private float parallaxSpeed;

    private void Awake()
    {
        //cameraTransfrom = GameObject.FindGameObjectWithTag("VCam").transform;
        cameraStartPos = cameraTransfrom.position;

        int backgroudCnt = transform.childCount;
        GameObject[] backgrounds = new GameObject[backgroudCnt];

        materials = new Material[backgroudCnt];
        layerMoveSpeed = new float[backgroudCnt];

        for(int i=0;i<backgroudCnt;i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        CalculateMoveSpeedByLayer(backgrounds, backgroudCnt);
    }

    private void CalculateMoveSpeedByLayer(GameObject[] _backgrounds, int _cnt)
    {
        float farthestBackDistance = 0;
        for(int i=0;i<_cnt;++i)
        {
            if((_backgrounds[i].transform.position.z - cameraTransfrom.position.z) > farthestBackDistance )
            {
                farthestBackDistance = _backgrounds[i].transform.position.z - cameraTransfrom.position.z;
            }
        }

        for(int i=0;i<_cnt;++i)
        {
            layerMoveSpeed[i] = 1-(_backgrounds[i].transform.position.z - cameraTransfrom.position.z) / farthestBackDistance;
        }

    }
    
    private void LateUpdate()
    {
        distance = cameraTransfrom.position.x - cameraStartPos.x;
        transform.position = new Vector3(cameraTransfrom.position.x, transform.position.y, 0);

        for(int i=0;i<materials.Length;++i)
        {
            float speed = layerMoveSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance,0)*speed); //카메라가 이동한 거리만큼 오프셋이 변화
        }
    }
}
