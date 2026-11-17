// Package graph provides graph traversal and shortest-path algorithms.
package graph

// Bfs returns the nodes of graph in breadth-first order from start.
//
// graph maps a node to its neighbors. Nodes unreachable from start are
// omitted, and start is always the first element of the result, even when it
// is absent from graph. The graph is not modified.
func Bfs(graph map[int][]int, start int) []int {
	visited := map[int]bool{start: true}
	order := []int{}
	queue := []int{start}

	for len(queue) > 0 {
		node := queue[0]
		queue = queue[1:]
		order = append(order, node)

		for _, neighbor := range graph[node] {
			if !visited[neighbor] {
				visited[neighbor] = true
				queue = append(queue, neighbor)
			}
		}
	}

	return order
}
