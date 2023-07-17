using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	[SerializeField] float _force;
	[SerializeField] float _gravityScaleUp;
	[SerializeField] float _gravityScaleDown;
	[SerializeField] float _upPower;

	Rigidbody2D _ballRb;
	Vector2 _dir;

	private void Update()
	{
		if (GameManager.Single.GameActive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector2 mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);

				Collider2D col = Physics2D.OverlapCircle(mousePos, 0.2f);
				if (col)
				{
					if (!_ballRb)
					{
						_ballRb = col.GetComponent<Rigidbody2D>();
					}

					_dir = (Vector2)col.transform.position - mousePos;
					_dir = new Vector2(_dir.x, _upPower).normalized;
					_ballRb.velocity = Vector2.zero;
					_ballRb.AddForce(_force * _dir, ForceMode2D.Impulse);
					_ballRb.gravityScale = _gravityScaleUp;

					GameManager.Single.AddScore();
				}
			}
		}
	}

    private void FixedUpdate()
    {
		if (!_ballRb) return;
        if (_ballRb.velocity.y < 0)
		{
			_ballRb.gravityScale = _gravityScaleDown;
		}
    }
}
