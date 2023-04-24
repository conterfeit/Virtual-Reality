using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Splitter_ZH : MonoBehaviour
{
    //�и�Ԥ�������
    public Material _NewMaterial;

    //���и�Ԥ��������
    public List<GameObject> _ListGamPreFab;


    void Update()
    {
        float _Mx = Input.GetAxis("Mouse X");

        transform.Rotate(0, 0, _Mx);

        //�����������ʱ
        if (Input.GetMouseButtonDown(0))
        {
            //���������и����
            Collider[] _Colliders = Physics.OverlapBox(transform.position, new Vector3(4, 0.00005f, 4), transform.rotation, ~LayerMask.GetMask("Solid"));

            foreach (var item in _Colliders)
            {
                Destroy(item.gameObject);

                //�и�
                //GameObject[] _objs GameObject[] _objs = item.gameObject.SliceInstantiate(transform.position, transform.up);

                //�и���ֵ�����
                SlicedHull _SlicedHull = item.gameObject.Slice(transform.position, transform.up);
                if (_SlicedHull != null)
                {
                    //�и��°벿�ֲ���  ����
                    GameObject _Lower = _SlicedHull.CreateLowerHull(item.gameObject, _NewMaterial);

                    //�и��ϰ벿�ֲ���  ����
                    GameObject _Upper = _SlicedHull.CreateUpperHull(item.gameObject, _NewMaterial);

                    GameObject[] _objs = new GameObject[] { _Lower, _Upper };

                    for (int i = 0; i < _objs.Length; i++)
                    {
                        _objs[i].AddComponent<Rigidbody>();
                        _objs[i].AddComponent<MeshCollider>().convex = true;
                    }
                }
            }
        }


        //��������
        if (Input.GetMouseButtonDown(1))
        {
            GameObject _GamPrefab = _ListGamPreFab[Random.Range(0, _ListGamPreFab.Count - 1)];

            if (_GamPrefab.GetComponent<Rigidbody>())
            {
                GameObject _NewGamPrefab = Instantiate(_GamPrefab);
                _NewGamPrefab.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);

            }
            else
            {
                _GamPrefab.AddComponent<Rigidbody>();

                GameObject _NewGamPrefab = Instantiate(_GamPrefab);
                _NewGamPrefab.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
            }
        }

    }
}
