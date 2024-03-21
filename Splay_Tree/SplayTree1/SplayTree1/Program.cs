
using System;

class GFG
{

	// Bir AVL ağacı nodu
	public class node
	{

		public int key;
		public node left, right;
	};

	//Verilen anahtarla ve boş sol ve sağ işaretçilerle yeni bir düğüm tahsis eden
	//yardımcı fonksiyon. 
	static node newNode(int key)
	{
		node Node = new node();
		Node.key = key;
		Node.left = Node.right = null;
		return (Node);
	}

	// Sağa doğru bir yardımcı fonksiyon
	// kökü y olan alt ağacı döndür
	static node rightRotate(node x)
	{
		node y = x.left;
		x.left = y.right;
		y.right = x;
		return y;
	}

	// Sola doğru bir yardımcı fonksiyon
	// kökü x olan alt ağacı döndür
	static node leftRotate(node x)
	{
		node y = x.right;
		x.right = y.left;
		y.left = x;
		return y;
	}

	//Bu fonksiyon anahtarı şuraya getirir:
	//Eğer anahtar ağaçta mevcutsa kök.
	//Eğer anahtar mevcut değilse, root'a en son erişilen öğeyi getirir.
	//Bu işlev ağacı değiştirir ve yeni kökü döndürür
	static node splay(node root, int key)
	{
		// Temel durumlar: kök boş veya
		// anahtar kökte mevcut
		if (root == null || root.key == key)
			return root;

		// Anahtar sol alt ağaçta bulunuyor
		if (root.key > key)
		{
			// Anahtar ağaçta değil, işimiz bitti
			if (root.left == null) return root;

			// Zig-Zig (Sol Sol) 
			if (root.left.key > key)
			{
				// İlk önce yinelemeli olarak şunu getir
				// Anahtar olarak sol-sol kökü			

				root.left.left = splay(root.left.left, key);

				// Kök için ilk döndürmeyi gerçekleştirin,
				// else'den sonra ikinci dönüş yapılıyor			
				root = rightRotate(root);
			}
			else if (root.left.key < key) // Zig-Zag (Left Right) 
			{
				// İlk önce yinelemeli olarak getir
				// Anahtar olarak sol-sağ kökü			
				root.left.right = splay(root.left.right, key);

				// root.left için ilk döndürmeyi gerçekleştirir
				if (root.left.right != null)
					root.left = leftRotate(root.left);
			}

			// Kök için ikinci rotasyonu gerçekleştir
			return (root.left == null) ?
								root : rightRotate(root);
		}
		else
		// Anahtar sağ alt ağaçta bulunuyor	
		{
			// Anahtar ağaçta değil, işimiz bitti
			if (root.right == null) return root;

			// Zag-Zig (Sağ Sol) 
			if (root.right.key > key)
			{
				// Anahtarı sağ-sol kökü olarak getir 
				root.right.left = splay(root.right.left, key);

				// root.right için ilk döndürmeyi gerçekleştirir
				if (root.right.left != null)
					root.right = rightRotate(root.right);
			}
			else if (root.right.key < key)  // Zag-Zag (Sağ Sağ) 
			{
				// Anahtarı sağ-sağ kök olarak getir ve ilk döndürmeyi yap	
				root.right.right = splay(root.right.right, key);
				root = leftRotate(root);
			}

			// Kök için ikinci rotasyonu gerçekleştirir
			return (root.right == null) ?
								root : leftRotate(root);
		}
	}

	//Splay ağacı için arama fonksiyonu. 
	//Bu fonksiyonun Splay Tree'nin yeni kökünü döndürdüğünü unutmayın. 
	//Eğer anahtar ağaçta mevcutsa köke taşınır.
	static node search(node root, int key)
	{
		return splay(root, key);
	}

	// Ağacın ön gezinme geçişini yazdıran bir yardımcı işlev.
	// Fonksiyon ayrıca her düğümün yüksekliğini de yazdırır
	static void preOrder(node root)
	{
		if (root != null)
		{
			Console.Write(root.key + " ");
			preOrder(root.left);
			preOrder(root.right);
		}
	}

	public static void Main(String[] args)
	{
		node root = newNode(100);
		root.left = newNode(50);
		root.right = newNode(200);
		root.left.left = newNode(40);
		root.left.left.left = newNode(30);
		root.left.left.left.left = newNode(20);

		root = search(root, 20);
		Console.Write("Preorder traversal of the" +
					" modified Splay tree is \n");
		preOrder(root);
	}
}
