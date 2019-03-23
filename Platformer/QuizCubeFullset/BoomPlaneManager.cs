using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPlaneManager : MonoBehaviour {

    private readonly int MAX_ARR = 9;

    public Kaboom[] boomPlane;
    public CubeTouchCheck[] touchCube;


    public GameObject explosion;
    GameObject explosion_clone;
    public GameObject warning;
    GameObject warning_clone;

    public bool start = false;
    public bool end = false;

    public float explosionTime = 0.8f;
    public float warningEffectTime = 3.5f;

    public int[] shape_Cross = { 1, 3, 4, 5, 7 };
    public int[] shape_X = { 0, 2, 4, 6, 8 };
    public int[] shape_col_1 = { 0, 3, 6 };
    public int[] shape_col_2 = { 1, 4, 7 };
    public int[] shape_col_3 = { 2, 5, 8 };
    public int[] shape_row_1 = { 0, 1, 2 };
    public int[] shape_row_2 = { 3, 4, 5 };
    public int[] shape_row_3 = { 6, 7, 8 };
    public int[] shape_diagonalR = { 2, 4, 6 };
    public int[] shape_diagonalL = { 0,4,8 };

    private IEnumerator Pattern;


    // Use this for initialization
    void Start () {
        boomPlane = new Kaboom[MAX_ARR];
        touchCube = new CubeTouchCheck[MAX_ARR];
        for(int i=0; i<MAX_ARR; i++)
        {
            boomPlane[i] = transform.Find("PlaneChild").GetChild(i).gameObject.GetComponent<Kaboom>();
            touchCube[i] = transform.Find("CubeChild").GetChild(i).gameObject.GetComponent<CubeTouchCheck>();
        }
	}
	
	// Update is called once per frame
	void Update () {
   
        if(start)
        {
            Pattern = Pattern1();
            StartCoroutine(Pattern);
            start = false;
        }
        if(end)
        {
            StopCoroutine(Pattern);
            end = false;
        }
   
	}

    IEnumerator Pattern1()
    {
        explosionTime = 0.8f;
        warningEffectTime = 3.5f;
        while (true)
        {
            StartCoroutine(executeExplosion(shape_Cross, 0f));

            StartCoroutine(executeExplosion(shape_X, 5f));

            StartCoroutine(executeExplosion(shape_col_1, 8f));
            StartCoroutine(executeExplosion(shape_col_2, 11f));
            StartCoroutine(executeExplosion(shape_col_3, 14f));
            StartCoroutine(executeExplosion(shape_row_1, 17f));
            StartCoroutine(executeExplosion(shape_row_2, 20f));
            StartCoroutine(executeExplosion(shape_row_3, 23f));
            yield return new WaitForSeconds(29f);
        }

    }

    IEnumerator Pattern2()
    {
        warningEffectTime = 1.5f;
        while (true)
        {
         
            StartCoroutine(executeExplosion(shape_row_1, 1f));
            StartCoroutine(executeExplosion(shape_col_3, 2f));
            StartCoroutine(executeExplosion(shape_row_3, 3f));
            StartCoroutine(executeExplosion(shape_col_1, 4f));
            StartCoroutine(executeExplosion(shape_diagonalR, 5.5f));
            StartCoroutine(executeExplosion(shape_diagonalL, 7f));
            yield return new WaitForSeconds(9f);

        }

    }

    IEnumerator executeExplosion(int[] shape, float execDelay)
    {
        yield return new WaitForSeconds(execDelay);
        TriggerWarningEffect(shape);
        yield return new WaitForSeconds(warningEffectTime);
        TriggerExplosion(shape);
        yield return new WaitForSeconds(0.3f);
        SetCubeFalse();
        yield return new WaitForSeconds(explosionTime);

    }



    void TriggerExplosion(int[] shape)
    {
        foreach(int num in shape)
        {
            boomPlane[num].Explode(explosion, explosionTime);
            touchCube[num].onTouch = true;

        }
      
    }

    void TriggerWarningEffect(int[] shape)
    {
        foreach (int num in shape)
        {
            boomPlane[num].WarningEffect(warning, warningEffectTime);
        }
    }

    void SetCubeFalse()
    {
        for (int i = 0; i < MAX_ARR; i++)
        {
            touchCube[i].onTouch = false;
        }
    }

    public void SetStart(bool isStart)
    {
        start = isStart;
    }

    public bool GetStart()
    {
        return start;
    }
    public void SetEnd(bool isEnd)
    {
        end = isEnd;
    }
}
