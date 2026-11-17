package graph

// Dfs returns the nodes of graph in depth-first order from start.
//
// graph maps a node to its neighbors. Nodes unreachable from start are
// omitted, and start is always the first element of the result, even when it
// is absent from graph. The graph is not modified.
func Dfs(graph map[int][]int, start int) []int {
	visited := map[int]bool{}
	order := []int{}

	var visit func(node int)
	visit = func(node int) {
		if visited[node] {
			return
		}

		visited[node] = true
		order = append(order, node)

		for _, neighbor := range graph[node] {
			visit(neighbor)
		}
	}

	visit(start)
	return order
}
