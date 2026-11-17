package graph

// Edge is a weighted connection to a neighbor node.
type Edge struct {
	To     int
	Weight int
}

// Dijkstra returns the shortest distance from start to every reachable node.
//
// graph maps a node to its outgoing edges, whose weights must be non-negative.
// Unreachable nodes are absent from the result, and start always maps to 0.
// The graph is not modified.
func Dijkstra(graph map[int][]Edge, start int) map[int]float64 {
	distances := map[int]float64{start: 0}
	visited := map[int]bool{}

	for {
		current, found := closestUnvisitedNode(distances, visited)
		if !found {
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

// closestUnvisitedNode returns the unvisited node with the smallest known
// distance and reports whether such a node exists.
func closestUnvisitedNode(distances map[int]float64, visited map[int]bool) (int, bool) {
	closest := 0
	found := false

	for node, distance := range distances {
		if visited[node] {
			continue
		}
		if !found || distance < distances[closest] {
			closest = node
			found = true
		}
	}

	return closest, found
}
