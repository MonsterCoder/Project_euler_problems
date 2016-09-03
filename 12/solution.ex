defmodule Triangular do
  def generate do
    Stream.unfold({0,1}, fn {acc, n} -> { acc+n, {acc+n, n+1} } end) 
  end


end
