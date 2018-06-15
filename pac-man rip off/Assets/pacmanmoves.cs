using UnityEngine;
using System.Collections;


public class pacmanmove : MonoBehaviour {
	public float speed = 0.4f;
	Vector2 dest = Vector2.zero;

	void Start() {
		dest = transform.position;
	}

	void FixedUpdate() {
		// Move Closer to Destination 
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);

		// Check for input if not moving
		if ((Vector2) transform.position == dest) {
			if (Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up))
				dest = (Vector2) transform.position + Vector2.up;
			if (Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right))
				dest = (Vector2) transform.position + Vector2.right;
			if (Input.GetKey(KeyCode.DownArrow) && Valid(-Vector2.up))
				dest = (Vector2) transform.position - Vector2.up;
			if (Input.GetKey(KeyCode.LeftArrow) && Valid(-Vector2.right))
				dest = (Vector2) transform.position - Vector2.right;
		}

	    // Animation Parameters
		Vector2 dir = dest - (Vector2) transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}
	

	bool Valid(Vector2 dir) {
		// cast line from 'next to pac-man' to 'pac-man'
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}
}