package graph

// Edge is a weighted connection to a neighbor node.
type Edge struct {
	To     int
	Weight int
}

// Dijkstra returns the shortest distance from start to every reachable node.
// Unreachable nodes are absent from the result.
func Dijkstra(graph map[int][]Edge, start int) map[int]float64 {
	distances := map[int]float64{start: 0}
	visited := map[int]bool{}

	for {
		current := -1
		for node, distance := range distances {
			if visited[node] {
				continue
			}
			if current == -1 || distance < distances[current] {
				current = node
			}
		}

		if current == -1 {
			break
		}

		visited[current] = true

		for _, edge := range graph[current] {
			candidate := distances[current] + float64(edge.Weight)
			if known, ok := distances[edge.To]; !ok || candidate < known {
				distances[edge.To] = candidate
			}
		}
	}

	return distances
}
