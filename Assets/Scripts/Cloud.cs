using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject cloudSphere;
    public int numSphereMin = 6;
    public int numSphereMax = 10;
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public Vector2 shpereScaleRangeX = new Vector2(4, 8);
    public Vector2 shpereScaleRangeY = new Vector2(3, 4);
    public Vector2 shpereScaleRangeZ = new Vector2(2, 4);

    public float scaleYMin = 2f;
    private List<GameObject> shperes;


    // Start is called before the first frame update
    void Start()
    {
        shperes = new List<GameObject>();
        int num = Random.Range(numSphereMin, numSphereMax);
        for (int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate<GameObject>(cloudSphere);
            shperes.Add(sp);
            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTrans.localPosition = offset;

            Vector3 scale = Vector3.one;
            scale.x = Random.Range(shpereScaleRangeX.x, shpereScaleRangeX.y);
            scale.y = Random.Range(shpereScaleRangeY.x, shpereScaleRangeY.y);
            scale.z = Random.Range(shpereScaleRangeZ.x, shpereScaleRangeZ.y);

            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYMin);
            spTrans.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }
    void Restart()
    {
        /* foreach (GameObject sp in shperes)
        {
            Destroy(sp);
        } */
        Start();
    }
}
