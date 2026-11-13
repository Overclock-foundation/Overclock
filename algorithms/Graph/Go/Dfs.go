package graph

// Dfs returns the nodes of graph in depth-first order from start.
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
