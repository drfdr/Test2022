using UnityEngine;

namespace Parabox.CSG.Demo{

	public class drfdrCSG : MonoBehaviour
	{
		GameObject left, right, composite;


		public GameObject Wall;
		public GameObject Hole;

		public GameObject instaGO;

		private RaycastHit rHit;

		enum BoolOp
		{
			Union,
			SubtractLR,
			SubtractRL,
			Intersect
		};


		void Update() {
			if (Input.GetKeyDown(KeyCode.R)) {
				xStart();
				SubtractionLR();

			}

            if (Input.GetKeyDown(KeyCode.Q)){
				xReset();
            }

            
	    if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out rHit, 15)) {
				Debug.Log(rHit.transform.name);
				Vector3 v3 = new Vector3(
					Mathf.Round(rHit.point.x),
					1,
					Mathf.Round(rHit.point.z));

				Hole.transform.position = v3;
				if (Input.GetKeyDown(KeyCode.E)) {
					
					
					
                }
            }
		}

		private void vInsta() {
			Hole = Instantiate(instaGO, rHit.point, Quaternion.identity);
		}



        public void xStart() {

			left = Wall;
			right = Hole;



			GenerateBarycentric(left);
			GenerateBarycentric(right);
		}

		void xReset() {
			left.SetActive(true);
			right.SetActive(true);
			Destroy(composite);
        }

        public void Union()
		{
			DoBooleanOperation(BoolOp.Union);
		}

		public void SubtractionLR()
		{
			
			DoBooleanOperation(BoolOp.SubtractLR);
		}

		public void SubtractionRL()
		{
			DoBooleanOperation(BoolOp.SubtractRL);
		}

		public void Intersection()
		{
			DoBooleanOperation(BoolOp.Intersect);
		}

		void DoBooleanOperation(BoolOp operation)
		{
			Model result;

			// All boolean operations accept two gameobjects and return a new mesh.
			// Order matters - left, right vs. right, left will yield different
			// results in some cases.
			switch (operation)
			{
				case BoolOp.Union:
					result = CSG.Union(left, right);
					break;

				case BoolOp.SubtractLR:
					result = CSG.Subtract(left, right);
					break;

				case BoolOp.SubtractRL:
					result = CSG.Subtract(right, left);
					break;

				default:
					result = CSG.Intersect(right, left);
					break;
			}

			composite = new GameObject();
			composite.AddComponent<MeshFilter>().sharedMesh = result.mesh;
			composite.AddComponent<MeshRenderer>().sharedMaterials = result.materials.ToArray();
			composite.AddComponent<MeshCollider>();

			GenerateBarycentric(composite);

			left.SetActive(false);
			right.SetActive(false);
		}



		/**
		 * Rebuild mesh with individual triangles, adding barycentric coordinates
		 * in the colors channel.  Not the most ideal wireframe implementation,
		 * but it works and didn't take an inordinate amount of time :)
		 */
		void GenerateBarycentric(GameObject go)
		{
			Mesh m = go.GetComponent<MeshFilter>().sharedMesh;

			if (m == null) return;

			int[] tris = m.triangles;
			int triangleCount = tris.Length;

			Vector3[] mesh_vertices = m.vertices;
			Vector3[] mesh_normals = m.normals;
			Vector2[] mesh_uv = m.uv;

			Vector3[] vertices = new Vector3[triangleCount];
			Vector3[] normals = new Vector3[triangleCount];
			Vector2[] uv = new Vector2[triangleCount];
			Color[] colors = new Color[triangleCount];

			for (int i = 0; i < triangleCount; i++)
			{
				vertices[i] = mesh_vertices[tris[i]];
				normals[i] = mesh_normals[tris[i]];
				uv[i] = mesh_uv[tris[i]];

				colors[i] = i % 3 == 0 ? new Color(1, 0, 0, 0) : (i % 3) == 1 ? new Color(0, 1, 0, 0) : new Color(0, 0, 1, 0);

				tris[i] = i;
			}

			Mesh wireframeMesh = new Mesh();

			wireframeMesh.Clear();
			wireframeMesh.vertices = vertices;
			wireframeMesh.triangles = tris;
			wireframeMesh.normals = normals;
			wireframeMesh.colors = colors;
			wireframeMesh.uv = uv;

			go.GetComponent<MeshFilter>().sharedMesh = wireframeMesh;
		}
	}
}
