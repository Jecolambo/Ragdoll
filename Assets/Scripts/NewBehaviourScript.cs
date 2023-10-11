using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   private Mesh OriginalMesh, MeshClone;
    private MeshRenderer meshRenderer;
    public float intensity, mass, stiffness, dampness;
    private Vector3[] vertexArray;
    private GameObjectVertex[] gamevertex;

    void Start()
    {
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        MeshClone = Instantiate(OriginalMesh);
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        meshRenderer = GetComponent<MeshRenderer>();

        gamevertex = new GameObjectVertex[MeshClone.vertices.length];
        for (int i = 0; i < MeshClone.vertices.Length; i++)
        {
            gamevertex[i] = new GameObjectVertex(i, TransformPoint(MeshClone.vertices[i]));
        }
    }

    void Update()
    {
        
    }

    public class GameObjectVertex
    {
        public int ID;
        public Vector3 position;
        public Vector3 velocity, force;
        
        public float speed;

        public GameObjectVertex(int _ID, Vector3 pos)
        {
            ID = _ID;
            position = pos;
        }
    }

    public void Shake(Vector3 target, float m, float s, float d)
    {
        force = (target - position) * s;
        velocity = (velocity + force / m) * d;
        position += velocity;
    }
    void FixedUpdate()
    {
        vertexArray = OriginalMesh.vertices;
        for (int i = 0; i < gamevertex.length;i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[gamevertex[i].ID]);

            float _intensity = (1-(meshRenderer.bounds.max.y - target.y) / meshRenderer.bounds.size.y) * intensity;
            gamevertex[i].Shake(target,mass,stiffness,dampness);
            vertexArray[gamevertex[i].ID] = Vector3.Lerp(vertexArray[gamevertex[i].ID], target, _intensity);
        }
    }
    
}
