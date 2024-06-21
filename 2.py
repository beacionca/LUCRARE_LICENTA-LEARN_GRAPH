import matplotlib.pyplot as plt
import networkx as nx
import os
import argparse

def calculate_node_depths(G, root):
    depths = {}
    stack = [(root, 0)]
    while stack:
        node, depth = stack.pop()
        if node not in depths:
            depths[node] = depth
            for neighbor in G.neighbors(node):
                stack.append((neighbor, depth + 1))
    return depths

def draw_tree_graph_with_weights(nodes, edges, output_file, bottom_text):
    # Crearea unui graf neorientat
    G = nx.DiGraph()
    
    # Adăugăm valorile nodurilor și ale ponderilor în graf
    G.add_nodes_from(nodes)
    G.add_weighted_edges_from(edges)
    
    # Căutăm nodurile rădăcină
    root_nodes = [node for node in G.nodes() if G.in_degree(node) == 0]
    if not root_nodes:
        raise ValueError("The graph must have at least one root node (node with no incoming edges).")
    
    # Calculează adâncimile nodurilor din rădăcină
    root = root_nodes[0]
    depths = calculate_node_depths(G, root)
    
    # Alocarea pozițiilor nodurilor pe baza adâncimilor
    pos = {}
    max_depth = max(depths.values())
    nodes_at_depth = {i: [] for i in range(max_depth + 1)}
    for node, depth in depths.items():
        nodes_at_depth[depth].append(node)
    
    for depth, nodes in nodes_at_depth.items():
        for i, node in enumerate(nodes):
            pos[node] = (i - len(nodes) / 2, -depth)
    
    # Crearea figurii și a axei
    fig, ax = plt.subplots(figsize=(3, 2))
    
    # Desenarea grafului
    nx.draw(G, pos, with_labels=True, node_size=400, node_color="lightblue", font_size=8, font_weight="bold", arrows=False, ax=ax)
    
    # Desenarea ponderilro
    edge_labels = nx.get_edge_attributes(G, 'weight')
    nx.draw_networkx_edge_labels(G, pos, edge_labels=edge_labels, font_color='red', ax=ax)
    
    # Adăugarea textului sub graful desenat
    plt.figtext(0.5, 0.01, bottom_text, ha='center', fontsize=12)
    
    # Ajustarea layout-ului pentru a face spațiu pentru text
    plt.subplots_adjust(bottom=0.2)
    
    # Salvăm imaginea
    plt.savefig(output_file, format='jpg')
    

def find_last_file_created(directory):
    max_number = -1
    max_file = None

    for filename in os.listdir(directory):
        # Extragerea partii cu numărul din numele fișierului
        number_part = filename.rstrip('.txt')
        if number_part.isdigit():  # Verifică dacă extracția conține doar numere
            number = int(number_part)
            if number > max_number:
                max_number = number
                max_file = filename

    if max_file is not None:
        return max_file
    else:
        return "Niciun fișier valid găsit."

def find_last_variant_created(directory):
    max_number = -1

    for filename in os.listdir(directory):
        # Extragerea partii cu numărul din numele fișierului
        number_part = filename.rstrip('.txt')
        if number_part.isdigit():  # Verifică dacă extracția conține doar numere
            number = int(number_part)
            if number > max_number:
                max_number = number

    if max_number == -1:
        return "Niciun fișier valid găsit."
    else:
        return max_number


def construct_nodes_values(filename):
    values = set()  # Folosim un set pentru a evita duplicatele
    with open(filename, 'r') as file:
        for line in file:
            try:
                num1, num2 = map(float, line.split()[:2])
                num1 = int(num1) if num1.is_integer() else num1
                num2 = int(num2) if num2.is_integer() else num2
                values.add(num1)
                values.add(num2)
            except ValueError:
                print(f"Linie invalidă: {line.strip()}")
    return list(values) 

def construct_edges(filename):
    edges = []
    try:
        with open(filename, 'r') as file:
            for line in file:
                # Împărțim linia în componente separate prin spațiu și convertim la int
                parts = line.split()
                if len(parts) == 3:
                    node1 = int(parts[0])
                    node2 = int(parts[1])
                    weight = int(parts[2])
                    # Adăugăm tuplul în lista de muchii
                    edges.append((node1, node2, weight))
                else:
                    print(f"Ignoring malformed line: {line.strip()}")
    except FileNotFoundError:
        print(f"File {filename} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")
    
    return edges

# Crearea unui ArgumentParser
parser = argparse.ArgumentParser(description="Script pentru a primi un string din linia de comandă")
    
# Adăugarea unui argument pentru string-ul de intrare
parser.add_argument('input_string', type=str, help='String-ul de intrare pentru script')
    
# Parsarea argumentelor din linia de comandă
args = parser.parse_args()
    
# Preluarea string-ului de intrare
input_string = args.input_string
    
# Afișarea string-ului primit
print(f"String-ul primit este: {input_string}")
    

data_folder = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/ARBORI_VALORI/"
data_file = find_last_file_created(data_folder)
data_complete_path = data_folder + data_file

output_folder = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/ARBORI_IMAGINI/"
output_file = str(find_last_variant_created(data_folder)) + ".jpg"
output_complete_path = output_folder + output_file

nodes = construct_nodes_values(data_complete_path)
edges = construct_edges(data_complete_path)
draw_tree_graph_with_weights(nodes, edges, output_complete_path, input_string)
