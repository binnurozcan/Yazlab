import networkx as nx
import matplotlib.pyplot as plt
import pyodbc

# MySQL bağlantısı
conn = pyodbc.connect(
    'DRIVER={SQL Server};'
    'SERVER=LAPTOP-CBRO5FHT;'
    'DATABASE=dersProgrami;'
    'PWD=1234;'
    'Trusted_Connection=True;'
)
cursor = conn.cursor()


# Akademisyen isimlerini veritabanından çek
cursor.execute("SELECT id, akademisyenadi FROM akademisyen")
akademisyenler = cursor.fetchall()

# Ders-Hoca ilişkilerini al
cursor.execute("SELECT dersid, akademisyenid FROM kisitlar")
ders_akademisyen = cursor.fetchall()

# Kısıtları al
cursor.execute("SELECT akademisyenid, dersgunu, derssaati FROM kisitlar")
kisitlar = cursor.fetchall()

# Ders isimlerini veritabanından çek
cursor.execute("SELECT id, dersadi FROM ders")
dersler = cursor.fetchall()

# Graf oluştur
G = nx.Graph()

for akademisyen in akademisyenler:
    G.add_node(f"Akademisyen_{akademisyen[0]}", label=f"{akademisyen[1]}", tur="Akademisyen", akademisyenid=akademisyen[0])

for ders in dersler:
    G.add_node(f"Ders_{ders[0]}", label=f"{ders[1]}", tur="Ders", dersid=ders[0])

for iliski in ders_akademisyen:
    G.add_edge(f"Ders_{iliski[0]}", f"Akademisyen_{iliski[1]}")
    #G.add_node(f"Ders_{iliski[0]}", label=f"Ders {iliski[0]}", tur="Ders", akademisyenid=iliski[1], dersid=iliski[0])
    #G.add_node(f"Akademisyen_{iliski[1]}", label=f"Akademisyen {iliski[1]}", tur="Akademisyen", akademisyenid=iliski[1])

for kisit in kisitlar:
    hoca_node = f"Akademisyen_{kisit[0]}"
    G.nodes[hoca_node]["dersgunu"] = kisit[1]
    G.nodes[hoca_node]["derssaati"] = kisit[2]
    
# renklendirme fonksiyonu
def custom_coloring(G):
    coloring = {}  
    for node in G.nodes:
        if satisfies_constraints(G.nodes[node], coloring):
            color = assign_color(node, coloring)
            coloring[node] = color
    return coloring


def satisfies_constraints(node, coloring):
    hoca_gun = node["dersgunu"]
    hoca_saat = node["derssaati"]
    hoca_id = node ["akademisyenid"]
    ders_id = node ["dersid"]
    for other_node, other_props in G.nodes.items():
        if (
            # Eğer aynı gün, saat, akademisyen ve ders ID'sine sahip bir başka düğüm varsa
            other_node != node and
            other_props.get("dersgunu") == hoca_gun and
            other_props.get("derssaati") == hoca_saat and
            other_props.get("akademisyenid") == hoca_id and
            other_props.get("dersid") == ders_id 
        ):
            return False
        if (
            # Eğer aynı gün ve saatte bir başka düğüm varsa
            other_node != node and
            other_props.get("dersgunu") == hoca_gun and
            other_props.get("derssaati") == hoca_saat             
        ):
            return False
        if ( # Eğer aynı gün, saat ve akademisyene sahip bir başka düğüm varsa
            other_node != node and
            other_props.get("dersgunu") == hoca_gun and
            other_props.get("derssaati") == hoca_saat and
            other_props.get("akademisyenid") == hoca_id
        ):
            return False
        if (# Eğer aynı gün, saat ve ders ID'sine sahip bir başka düğüm varsa
            other_node != node and
            other_props.get("dersgunu") == hoca_gun and
            other_props.get("derssaati") == hoca_saat and
            other_props.get("dersid") == ders_id
        ):
            return False
        # Eğer yukarıdaki koşulların hiçbiri sağlanmıyorsa, kısıtlamalar sağlanıyor demektir
    return True


# Düğümlere renk atayan fonksiyon
def assign_color(node, coloring):
    if satisfies_constraints(node, coloring):
        color = assign_color(node, coloring)
        return color
    else:
        return 1
    

# Greedy renklendirme algoritması kullanılarak düğümlere renk atama
coloring = nx.coloring.greedy_color(G, strategy="largest_first")
# Düğüm etiketleri
labels = {node: G.nodes[node]['label'] for node in G.nodes}

print("Düğüm Sayısı:", G.number_of_nodes())
print("Kenar Sayısı:", G.number_of_edges())
print("Bağlantı Bileşenleri:", list(nx.connected_components(G)))


#Graf çizimi
nx.draw(
    G,
    with_labels=True,
    labels=labels,
    font_weight="bold",
    node_color=list(coloring.values()),
    cmap=plt.cm.rainbow,
    node_size=100,
    edge_color='gray',
    width=1.5,
    node_shape='s',
)
plt.title("GRAFIK")
plt.show()

#SQL bağlantısını kapatma
cursor.close()
conn.close()