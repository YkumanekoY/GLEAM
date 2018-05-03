using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// A-star algorithm
public class AStar : MonoBehaviour
{

	public GameObject Enemy;


    struct Point2
    {
        public int x;
        public int y;

        public Point2(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    /// A-starノード.
    class ANode
    {
        enum eStatus
        {
            None,
            Open,
            Closed,
        }

        /// ステータス
        eStatus _status = eStatus.None;

        /// 実コスト
        int _cost = 0;

        /// ヒューリスティック・コスト
        int _heuristic = 0;

        /// 親ノード
        ANode _parent = null;

        /// 座標
        int _x = 0;

        int _y = 0;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int Cost
        {
            get { return _cost; }
        }

        /// コンストラクタ.
        public ANode(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// スコアを計算する.
        public int GetScore()
        {
            return _cost + _heuristic;
        }

        /// ヒューリスティック・コストの計算.
        public void CalcHeuristic(bool allowdiag, int xgoal, int ygoal)
        {
            if (allowdiag)
            {
                // 斜め移動あり
                var dx = (int) Mathf.Abs(xgoal - X);
                var dy = (int) Mathf.Abs(ygoal - Y);
                // 大きい方をコストにする
                _heuristic = dx > dy ? dx : dy;
            }
            else
            {
                // 縦横移動のみ
                var dx = Mathf.Abs(xgoal - X);
                var dy = Mathf.Abs(ygoal - Y);
                _heuristic = (int) (dx + dy);
            }

        }

        /// ステータスがNoneかどうか.
        public bool IsNone()
        {
            return _status == eStatus.None;
        }

        /// ステータスをOpenにする.
        public void Open(ANode parent, int cost)
        {
            _status = eStatus.Open;
            _cost = cost;
            _parent = parent;
        }

        /// ステータスをClosedにする.
        public void Close()
        {
            Debug.Log(string.Format("Closed: ({0},{1})", X, Y));
            _status = eStatus.Closed;
        }

        /// パスを取得する
        public void GetPath(List<Point2> pList)
        {
            pList.Add(new Point2(X, Y));
            if (_parent != null)
            {
                _parent.GetPath(pList);
            }
        }
    }

    /// A-starノード管理.
    class ANodeMgr
    {
        /// 斜め移動を許可するかどうか.
        bool _allowdiag = true;

        /// オープンリスト.
        List<ANode> _openList = null;

        /// ノードインスタンス管理.
        Dictionary<int, ANode> _pool = null;

        /// ゴール座標.
        int _xgoal = 0;

        int _ygoal = 0;

        public ANodeMgr(int xgoal, int ygoal, bool allowdiag = true)
        {
            _allowdiag = allowdiag;
            _openList = new List<ANode>();
            _pool = new Dictionary<int, ANode>();
            _xgoal = xgoal;
            _ygoal = ygoal;
        }

        /// ノード生成する.
        public ANode GetNode(int x, int y, int[,] map)
        {
            var idx = x + (y * map.GetLength(0));
            if (_pool.ContainsKey(idx))
            {
                // 既に存在しているのでプーリングから取得.
                return _pool[idx];
            }

            // ないので新規作成.
            var node = new ANode(x, y);
            _pool[idx] = node;
            // ヒューリスティック・コストを計算する.
            node.CalcHeuristic(_allowdiag, _xgoal, _ygoal);
            return node;
        }

        /// ノードをオープンリストに追加する.
        public void AddOpenList(ANode node)
        {
            _openList.Add(node);
        }

        /// ノードをオープンリストから削除する.
        public void RemoveOpenList(ANode node)
        {
            _openList.Remove(node);
        }

        /// 指定の座標にあるノードをオープンする.
        public ANode OpenNode(int x, int y, int cost, ANode parent, int[,] map)
        {
            // 座標をチェック.
            if (x < 0 || map.GetLength(0) <= x || y < 0 || map.GetLength(1) <= y)
            {
                // 領域外.
                return null;
            }

            if (map[x, y] == 1)
            {
                // 通過できない.
                return null;
            }

            // ノードを取得する.
            var node = GetNode(x, y, map);
            if (node.IsNone() == false)
            {
                // 既にOpenしているので何もしない
                return null;
            }

            // Openする.
            node.Open(parent, cost);
            AddOpenList(node);

            return node;
        }

        /// 周りをOpenする.
        public void OpenAround(ANode parent, int[,] map)
        {
            var xbase = parent.X; // 基準座標(X).
            var ybase = parent.Y; // 基準座標(Y).
            var cost = parent.Cost; // コスト.
            cost += 1; // 一歩進むので+1する.
            if (_allowdiag)
            {
                // 8方向を開く.
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var x = xbase + i - 1; // -1～1
                        var y = ybase + j - 1; // -1～1
                        OpenNode(x, y, cost, parent, map);
                    }
                }
            }
            else
            {
                // 4方向を開く.
                var x = xbase;
                var y = ybase;
                OpenNode(x - 1, y, cost, parent, map); // 右.
                OpenNode(x, y - 1, cost, parent, map); // 上.
                OpenNode(x + 1, y, cost, parent, map); // 左.
                OpenNode(x, y + 1, cost, parent, map); // 下.
            }
        }

        /// 最小スコアのノードを取得する.
        public ANode SearchMinScoreNodeFromOpenList()
        {
            // 最小スコア
            int min = 9999;
            // 最小実コスト
            int minCost = 9999;
            ANode minNode = null;
            foreach (ANode node in _openList)
            {
                int score = node.GetScore();
                if (score > min)
                {
                    // スコアが大きい
                    continue;
                }

                if (score == min && node.Cost >= minCost)
                {
                    // スコアが同じときは実コストも比較する
                    continue;
                }

                // 最小値更新.
                min = score;
                minCost = node.Cost;
                minNode = node;
            }

            return minNode;
        }
    }

    /// ランダムな座標を取得する.
    Point2 GetRandomPosition(int[,] map)
    {
        Point2 p;
        while (true)
        {
            p.x = Random.Range(0, map.GetLength(0));
            p.y = Random.Range(0, map.GetLength(1));
            if (map[p.x, p.y] == 0)
            {
                // 通過可能
                break;
            }
        }

        return p;
    }

    IEnumerator Start()
    {
		var map =new int[11,11]{
			{1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,0,2,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,2,0,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,1,1,1,1,1}
		};	 //0を何もないところ1を障害物アリとする //大きさを変更したり個々の値を変更すると障害物アリで出来る。

        // A-star実行.

        // スタート地点.ランダムに設定(ここを使うものに変更)
		Point2 pStart = GetRandomPosition(map);
		Vector3 Epoint = Enemy.transform.position;
		Epoint.x = pStart.x;
		Epoint.z = pStart.y;
		Enemy.transform.position = Epoint;

        // ゴール地点.ランダムに設定(ここを使うものに変更)
        Point2 pGoal = GetRandomPosition(map);
        // 斜め移動を許可
        var allowdiag = false;

        var pList = CalcPath(pStart, pGoal, map, allowdiag); //ここで経路の計算をしてる、これを実行すれば移動のパスを手に入れられる。
        Debug.Log("開始地点:x座標:"+pStart.x+"y座標:"+pStart.y);
        Debug.Log("終了地点:x座標:"+pGoal.x+"y座標:"+pGoal.y);

        // プレイヤーを移動させる.
        foreach (var p in pList)
        {
			Vector3 tempSpear = Enemy.transform.position;
			tempSpear.x = p.x;
			tempSpear.z = p.y;
			Enemy.transform.position = tempSpear;
            Debug.Log("X座標：" + p.x + "y座標:" + p.y);
            yield return new WaitForSeconds(0.2f);
        }

        // おしまい
    }


    List<Point2> CalcPath(Point2 pStart, Point2 pGoal, int[,] map, bool allowdiag)
    {
        var pList = new List<Point2>();
        var mgr = new ANodeMgr(pGoal.x, pGoal.y, allowdiag);

        // スタート地点のノード取得
        // スタート地点なのでコストは「0」
        ANode node = mgr.OpenNode(pStart.x, pStart.y, 0, null, map);
        mgr.AddOpenList(node);

        // 試行回数。1000回超えたら強制中断
        int cnt = 0;
        while (cnt < 1000)
        {
            mgr.RemoveOpenList(node);
            // 周囲を開く
            mgr.OpenAround(node, map);
            // 最小スコアのノードを探す.
            node = mgr.SearchMinScoreNodeFromOpenList();
            if (node == null)
            {
                // 袋小路なのでおしまい.
                Debug.Log("Not found path.");
                break;
            }

            if (node.X == pGoal.x && node.Y == pGoal.y)
            {
                // ゴールにたどり着いた.
                Debug.Log("Success.");
                mgr.RemoveOpenList(node);
                // パスを取得する
                node.GetPath(pList);
                // 反転する
                pList.Reverse();
                break;
            }
        }

        return pList;
    }
}