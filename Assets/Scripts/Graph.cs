using UnityEngine;

// One of these seemed to be needed for the script to run in the scene view,
// but I think if I go to play mode and switch back to scene view, the script will keep running.
// If I stop play mode, the pre-fabs are destroyed.
//[ExecuteInEditMode]
//[ExecuteAlways]

public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10,100)]
	int resolution = 10;

	Transform[] points;

	void Awake()
	{
		// We're making our cubes take positions 0 to 1 because this is a convenient range to work with.
		// We scale down the size to make it fit

		float step = 2f / resolution;
		var position = Vector3.zero;
		var scale = Vector3.one * step;     // .one is a Vector [ 1, 1, 1 ]

		//for (int i = 0; i < resolution; i++)

		points = new Transform[resolution];
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i] = Instantiate(pointPrefab);
			//Transform point = Instantiate(pointPrefab);
			//point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f);// .right is a Vector with x set to 1 [ 1, 0, 0 ]
			position.x = (i + 0.5f) * step - 1f;
			position.y = Mathf.Sin(position.x * 5f);			
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform, false);
		}
	}


	void Update()
	{
		float time = Time.time;
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i];
			if (point) // If I delete points in the editor, the script throws an error
            {
				Vector3 position = point.localPosition;
				//position.y = position.x * position.x * position.x;
				position.y = Mathf.Sin(Mathf.PI * (position.x + time));
				point.localPosition = position;
            }
		}
	}
}
