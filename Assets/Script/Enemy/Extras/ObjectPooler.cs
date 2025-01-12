using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;//������еĶ���
    [SerializeField] private int poolSize = 10;

    private List<GameObject> _pool;
    private GameObject _poolContainer;//���������(�������ˢ�²�ͬ�������)

    private void Awake()
    {
        _pool = new List<GameObject>();//��ʼ�������
        _poolContainer = new GameObject($"Pool - {prefab.name}");//����һ�����������
        CreatePooler();//���������(�ܵĵ�������)
    }


    //���������
    private void CreatePooler()
    {
        for (int i = 0; i < poolSize; i++)
        {
            _pool.Add(CreateInsatnce());
        }
    }

    //��������ʵ��
    private GameObject CreateInsatnce() { 
        GameObject newinstance = Instantiate(prefab, transform);
        newinstance.transform.SetParent(_poolContainer.transform);//�����������������
        newinstance.SetActive(false);
        return newinstance;
    }

    //�Ӷ�����л�ȡ����
    public GameObject GetInstanceFromPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].activeInHierarchy)
            {
                return _pool[i];
            }
        }
        return CreateInsatnce();
    }








}
